using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Arguments.Base;
using System.Collections.Generic;

namespace pegabicho.domain.Arguments.Core.Security {
    public class AuthResponse : IResponse {
        
        public string Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<AccessResponse> Profiles { get; set; }

        #region [ casting ]

        public static explicit operator AuthResponse(User v) {
            return v == null ? null : new AuthResponse {
                Id = v.Id,
                Email = v.Email,
                Profiles = v.Profiles?.ConvertAll(e => (AccessResponse)e),
            };
        }

        #endregion
    }
}