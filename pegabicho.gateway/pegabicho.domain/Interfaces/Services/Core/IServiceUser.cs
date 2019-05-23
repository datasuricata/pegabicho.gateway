using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceUser {
        User GetMe(string id);
        User GetByEmail(string email);
        User GetById(string id);
        List<User> ListUsers();

        AuthResponse Authenticate(AuthRequest request, AuthPlataform plataform);

        void InitialRegister(UserRequest request);
        void GeneralRegister(GeneralRequest request);
        void DocumentsRegister(List<DocumentRequest> requests, User user);
        void BussinesRegister(BussinesRequest request);
        void AddressRegister(AddressRequest request);
    }
}
