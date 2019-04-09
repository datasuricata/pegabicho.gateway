using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users
{
    public class Access : EntityBase
    {
        public UserType UserType { get; set; }
        public UserStage UserStage { get; set; }
        public UserRole UserRole { get; set; }
    }
}
