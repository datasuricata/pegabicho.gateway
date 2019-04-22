using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class UserRequest : IRequest{
        public UserType Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
