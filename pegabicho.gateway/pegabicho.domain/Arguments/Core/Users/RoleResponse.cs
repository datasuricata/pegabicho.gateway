using System;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class RoleResponse : IResponse {

        public LevelAccess Level { get; set; }
        public ModuleService Module { get; set; }

        #region [ casting ]

        public static explicit operator RoleResponse(Role v) {
            return v == null ? null : new RoleResponse {
                Level = v.Level,
                Module = v.Module,
            };
        }

        #endregion
    }
}
