using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.domain.Security;
using pegabicho.infra.Specs.Users;
using pegabicho.infra.Transaction;
using pegabicho.service.Services.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Services.Core {
    public class ServiceUser : ServiceApp<User>, IServiceUser {

        #region [ attributes ]

        /// <summary>
        /// Use this to retrive JWT key from config
        /// </summary>
        private readonly IConfiguration configuration;

        #endregion

        #region [ ctor ]

        public ServiceUser(IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IRepository<User> repository) : base(repository, unitOfWork) {
            this.configuration = configuration;
        }

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
                NotifyException<ServiceUser>("Error to get logged user.", ex);
                return null;
            }
        }

        /// <summary>
        /// Use this to retrive user by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User GetByLogin(string login) {
            try {
                return repository.GetBy(m => m.Login.ToLower() == login.ToLower());
            } catch (Exception ex) {
                NotifyException<ServiceUser>("Erro to list user.", ex);
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

                bool isValid = DataSecurity.IsValid(GetByLogin(request.Login), request.Plataform);

                if (!isValid) 
                    throw new ValidationException("Voce nao tem acesso a plataforma. Contate o suporte.");

                var user = repository.GetBy(SpecUser.Auth(new User(request.Login, request.Password)));

                if (user == null) 
                    throw new ValidationException("Verifique seu login e senha.");

                if (user.Stage == UserStage.Blocked) 
                    throw new ValidationException("Sua conta esta bloqueada. Contate o suporte.");

                var Handler = new JwtSecurityTokenHandler();
                var Key = Encoding.ASCII.GetBytes(configuration["SecurityKey"]);

                //int role = (int)user.Role; passar lista de roles

                var Payload = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        //new Claim(ClaimTypes.Role, role.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                        SecurityAlgorithms.HmacSha256Signature),
                    IssuedAt = DateTime.UtcNow,
                };

                var Token = Handler.CreateToken(Payload);

                return ((AuthResponse)user).InjectToken(Handler.WriteToken(Token));
            } catch (Exception ex) {
                NotifyException<ServiceUser>("Error to authenticate.", ex);
                return null;
            }
        }

        #endregion

        #region [  ]

        #endregion

        /// <summary>
        /// Use this to retrive all user from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResponse> ListAll() {
            try {
                var users = BaseGetAll() as List<User>;
                return users.ConvertAll(e => (UserResponse)e);
            } catch (Exception ex) {
                NotifyException<ServiceUser>("Error to list users.", ex);
                return null;
            }
        }
    }
}
