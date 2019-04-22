using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Helpers;
using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Core.Users {
    public class DocumentResponse : IResponse {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public string Type { get; set; }

        public static explicit operator DocumentResponse(Document v) {
            return v == null ? null : new DocumentResponse {
                Type = v.Type.EnumDisplay(),
                ImageUri = v.ImageUri,
                Value = v.Value,
                Id = v.Id,
            };
        }
    }
}