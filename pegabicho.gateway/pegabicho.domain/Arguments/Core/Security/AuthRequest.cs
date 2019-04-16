using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Security {
    public class AuthRequest : IRequest {

        public string Email { get; set; }
        public string Password { get; set; }
        public AuthPlataform Plataform { get; set; }
    }
}
