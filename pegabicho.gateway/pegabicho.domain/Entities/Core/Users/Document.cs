using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Document : EntityBase
    {
        public string DocValue { get; set; }
        public string DocUri { get; set; }
        public DocumentType Type { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
