using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using System.Threading.Tasks;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceUser
    {
        // # get
        User GetMe(string id);
        User GetByEmail(string email);
        UserResponse GetById(string id);
        AuthResponse Authenticate(AuthRequest request);

        // # post
        Task StepRegister(UserInitialRequest request);
    }
}
