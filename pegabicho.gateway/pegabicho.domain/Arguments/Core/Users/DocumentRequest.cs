using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class DocumentRequest : IRequest {
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public DocumentType Type { get; set; }
    }
}
