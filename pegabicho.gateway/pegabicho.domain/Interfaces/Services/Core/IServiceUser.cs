using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceUser
    {
        // # get
        User GetMe(string id);
        User GetByEmail(string email);
        UserResponse GetById(string id);
        IEnumerable<UserResponse> ListAll();

        // # auth
        AuthResponse Authenticate(AuthRequest request, AuthPlataform plataform);

        // # post
        void InitialRegister(UserRequest request);
        void GeneralRegister(GeneralRequest request);
        void DocumentsRegister(List<DocumentRequest> requests, User user);
        void BussinesRegister(BussinesRequest request);
        void AddressRegister(AddressRequest request);
    }
}
