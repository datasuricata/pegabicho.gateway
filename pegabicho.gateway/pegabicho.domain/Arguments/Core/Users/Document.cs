using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users
{
    public class Document : EntityBase
    {
        public string DocValue { get; set; }
        public string DocUri { get; set; }
        public DocumentType Type { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
