using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Arguments.Base;
using System;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class AccessResponse : IResponse {

        public UserType Type { get; private set; }
        public UserStage Stage { get; private set; }
        public List<RoleResponse> Roles { get; set; }

        #region [ casting ]

        public static explicit operator AccessResponse(Access v) {
            return v == null ? null : new AccessResponse {
                Stage = v.Stage,
                Type = v.Type,
                Roles = v.Roles?.ConvertAll(e => (RoleResponse)e),
            };
        }

        #endregion
    }
}
