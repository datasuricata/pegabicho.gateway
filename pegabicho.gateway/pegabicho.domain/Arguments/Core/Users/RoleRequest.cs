using pegabicho.domain.Interfaces.Arguments.Base;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class RoleRequest : IRequest {
        public string UserId { get; set; }
        public List<ModuleService> Modules { get; set; }
    }
}
