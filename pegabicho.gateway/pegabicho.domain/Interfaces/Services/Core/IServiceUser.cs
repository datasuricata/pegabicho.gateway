using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Entities.Core.Users;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceUser
    {
        User GetMe(string id);
        User GetByEmail(string email);
        AuthResponse Authenticate(AuthRequest request);
    }
}
