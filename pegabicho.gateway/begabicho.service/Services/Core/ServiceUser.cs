using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.domain.Security;
using pegabicho.infra.Specs.Users;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Users;
using pegabicho.service.Validators.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Services.Core {
    public class ServiceUser : ServiceApp<User>, IServiceUser {

        #region [ attributes ]

        /// <summary>
        /// Use this to retrive JWT key from config
        /// </summary>
        private readonly IConfiguration appConf;

        #endregion

        #region [ ctor ]

        public ServiceUser(IServiceProvider provider, IConfiguration appConf) : base(provider) {
            this.appConf = appConf;
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
                Notifier.AddException<ServiceUser>("Erro ao obter usuário logado.", ex);
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
                var user = repository.GetBy(m => m.Email.ToLower() == email.ToLower());
                Notifier.When<ServiceUser>(user is null, "Usuário não encontrado.");
                return user;
            } catch (Exception ex) {
                Notifier.AddException<ServiceUser>("Erro ao retornar usuário.", ex);
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
        public AuthResponse Authenticate(AuthRequest request, AuthPlataform plataform) {
            try {

                if (request == null)
                    return null;

                var user = repository.GetByReadOnly(SpecUser.Auth(new User(request.Email, request.Password)), i => i.Profiles);

                Notifier.When<ServiceUser>(!DataSecurity.IsValid(user, plataform), 
                    "Voce nao tem acesso a plataforma. Contate o suporte.");

                ValidEntity<SecurityValidator>(user);

                var Handler = new JwtSecurityTokenHandler();
                var Key = Encoding.ASCII.GetBytes(appConf["SecurityKey"]);
                var Roles = JsonConvert.SerializeObject(user.Profiles.ConvertAll(e => (AccessResponse)e));

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
                Notifier.AddException<ServiceUser>("Erro para autenticar.", ex);
                return null;
            }
        }

        #endregion

        #region [ get ]

        public User GetById(string id) {
            try {
                return repository.GetById(id, i => i.General, i => i.Documents);
            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Usuário não encontrado.", e);
                return null;
            }
        }

        public List<User> ListUsers() {
            try {
                return repository.ListByReadOnly(x => !x.IsDeleted).ToList();
            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao listar usuários", e);
                return null;
            }
        }

        #endregion

        #region [ register ]

        public void InitialRegister(UserRequest request) {
            try {

                if (repository.Exist(x => x.Email == request.Email && x.Profiles.Any(a => request.Type == a.Type)))
                    Notifier.Add<ServiceUser>("Já existe um perfil cadastrado com os mesmos dados.");

                // todo confirm e-mail

                ValidRegister<UserValidator>(User.Register(request.Type, request.Email, request.Password));

            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao adicionar usuário", e);
            }
        }

        public void ModulesRegister(RoleRequest request) {
            try {

                throw new NotImplementedException();

            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao adicionar usuário", e);
            }
        }

        public void GeneralRegister(GeneralRequest request) {
            try {

                var user = repository.GetById(request.UserId);
                user.AddGeneral(request.Type, request.Phone, request.CellPhone, request.FirstName, request.LastName, request.BirthDate);
                ValidUpdate<UserValidator>(user);

            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao registrar informações gerais.", e);
            }
        }

        public void DocumentsRegister(List<DocumentRequest> requests, User user) {
            try {
                var documents = requests.Select(x => new Document(x.Value, x.ImageUri, x.Type)).ToList();
                user.AddDocument(documents);
                ValidUpdate<UserValidator>(user);
            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao adicionar documentos.", e);
            }
        }

        /// <summary>
        /// Use this after register GeneralRegister() method
        /// </summary>
        /// <param name="request"></param>
        public void BussinesRegister(BussinesRequest request) {
            try {
                var user = repository.GetById(request.UserId, i => i.General);
                user.AddBussines(request.Activity, request.InscMunicipal, request.InscEstadual, request.Representation);
                ValidUpdate<UserValidator>(user);

            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao adicionar informações da empresa", e);
            }
        }

        public void AddressRegister(AddressRequest request) {
            try {
                var user = repository.GetById(request.UserId);
                user.AddAddress(request.AddressLine, request.Complement, request.Building, request.Number,
                    request.District, request.City, request.StateProvince, request.Country, request.PostalCode);
                ValidUpdate<UserValidator>(user);
            } catch (Exception e) {
                Notifier.AddException<ServiceUser>("Erro ao registrar endereço.", e);
            }
        }

        #endregion
    }
}
