using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.domain.Interfaces.Services.Events;
using pegabicho.domain.Security;
using pegabicho.infra.Specs.Users;
using pegabicho.infra.Transaction;
using pegabicho.service.Services.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace pegabicho.service.Services.Core {
    public class ServiceUser : ServiceApp<User>, IServiceUser {

        #region [ attributes ]

        /// <summary>
        /// Use this to retrive JWT key from config
        /// </summary>
        private readonly IConfiguration appConf;
        public ServiceUser(IServiceProvider provider, IConfiguration appConf) : base(provider) {
            this.appConf = appConf;
        }

        #endregion

        #region [ ctor ]


        #endregion

        #region [ default ]

        /// <summary>
        /// Use this to retrive user by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetMe(string id) {
            try {
                return repository.GetById(id);
            } catch (Exception ex) {
                Notifier.AddException<ServiceUser>("Error to get logged user.", ex);
                return null;
            }
        }

        /// <summary>
        /// Use this to retrive user by login
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetByEmail(string email) {
            try {
                return repository.GetBy(m => m.Email.ToLower() == email.ToLower());
            } catch (Exception ex) {
                Notifier.AddException<ServiceUser>("Erro to get user.", ex);
                return null;
            }
        }

        #endregion

        #region [ security ]

        /// <summary>
        /// Use this to valid and create a jwt response from parameters request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AuthResponse Authenticate(AuthRequest request) {
            try {
                if (request == null)
                    return null;

                bool isValid = DataSecurity.IsValid(GetByEmail(request.Email), request.Plataform);

                if (!isValid)
                    throw new ValidationException("Voce nao tem acesso a plataforma. Contate o suporte.");

                var user = repository.GetBy(SpecUser.Auth(new User(request.Email, request.Password)));

                //todo fluent validator (block, exist, valid access)

                if (user == null)
                    throw new ValidationException("Verifique seu login e senha.");

                var Handler = new JwtSecurityTokenHandler();
                var Key = Encoding.ASCII.GetBytes(appConf["SecurityKey"]);
                var Roles = JsonConvert.SerializeObject(user.Profiles);

                var Payload = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Role, (string)Roles),
                    }),
                    Expires = DateTime.UtcNow.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                        SecurityAlgorithms.HmacSha256Signature),
                    IssuedAt = DateTime.UtcNow,
                };

                var Token = Handler.CreateToken(Payload);

                return ((AuthResponse)user).InjectToken(Handler.WriteToken(Token));
            } catch (Exception ex) {
                Notifier.AddException<ServiceUser>("Error to authenticate.", ex);
                return null;
            }
        }

        #endregion

        #region [ methods ]

        public UserResponse GetById(string id) {
            try {
                return (UserResponse)repository.GetById(id, i => i.General, i => i.Documents);

            } catch (Exception e) {
                Notifier.AddException<ServiceUser>(e.Message, e);
                return null;
            }
        }

        public async Task StepRegister(UserInitialRequest request) {

            try {
                var exist = repository.Exist(x => x.Email == request.Email && x.Profiles.Any(a => request.Type == a.Type));
                if (exist)
                    throw new ValidationException("Voce nao tem acesso a plataforma. Contate o suporte.");

                var user = User.Register(request.Type, request.Email, request.Password);

                await repository.RegisterAsync(user);
                //todo confirm e-mail
            } catch (Exception e) {
                Notifier.AddException<ServiceUser>(e.Message, e);
            }
        }

        /// <summary>
        /// Use this to retrive all user from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResponse> ListAll() {
            try {
                return repository.ListBy(x => !x.IsDeleted).ToList()
                    .ConvertAll(e => (UserResponse)e);

            } catch (Exception ex) {
                Notifier.AddException<ServiceUser>("Error to list users.", ex);
                return null;
            }
        }

        #endregion
    }
}
