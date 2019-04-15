using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Arguments.Base;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Security {
    public class AuthResponse : IResponse {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public UserStage Stage { get; set; }
        public UserType Type { get; set; }
        public List<AccessResponse> Access { get; set; }

        #region [ casting ]

        public static explicit operator AuthResponse(User v) {
            return v == null ? null : new AuthResponse {
                Id = v.Id,
                Type = v.Type,
                Stage = v.Stage,
                Name = v.General.GetName(),
                Access = v.Access.ConvertAll(e => (AccessResponse)e)
            };
        }

        #endregion
    }
}