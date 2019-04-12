﻿using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Wallet : EntityBase
    {
        public PaymentType Type { get; set; }

        public string Agency { get; set; }
        public string Account { get; set; }
        public string Document { get; set; }

        public int DateDue { get; set; }

        public bool IsDefault { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
    }
}