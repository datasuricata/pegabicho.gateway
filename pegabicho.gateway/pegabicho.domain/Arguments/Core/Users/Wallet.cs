using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users
{
    public class Wallet : EntityBase
    {
        public PaymentType Type { get; set; }

        public string Agency { get; set; }
        public string Account { get; set; }
        public string Document { get; set; }

        public int DateDue { get; set; }

        public bool IsDefault { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
