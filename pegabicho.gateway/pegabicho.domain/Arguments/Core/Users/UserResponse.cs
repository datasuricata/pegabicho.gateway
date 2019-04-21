using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Arguments.Base;
using System.Collections.Generic;

namespace pegabicho.domain.Arguments.Core.Users {
    public class UserResponse : IResponse {

        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public string Email { get; set; }
        public GeneralResponse General { get; set; }
        public List<DocumentResponse> Documents { get; set; }

        public static explicit operator UserResponse(User v) {
            return v == null ? null : new UserResponse {
                Id = v.Id,
                Email = v.Email,
                General = (GeneralResponse)v.General,
                CreatedAt = v.CreatedAt?.ToString("dd/MM/yyyy HH:mm"),
                Documents = v.Documents?.ConvertAll(e => (DocumentResponse)e),
            };
        }
    }
}
