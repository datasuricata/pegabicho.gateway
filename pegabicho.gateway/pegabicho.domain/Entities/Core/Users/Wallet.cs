using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Wallet : EntityBase
    {
        public Wallet(PaymentType type, string agency, string account, string document, int dateDue, bool isDefault) {
            Type = type;
            Agency = agency;
            Account = account;
            Document = document;
            DateDue = dateDue;
            IsDefault = isDefault;
        }

        protected Wallet() {

        }

        public PaymentType Type { get; private set; }

        public string Agency { get; private set; }
        public string Account { get; private set; }
        public string Document { get; private set; }

        public int DateDue { get; private set; }

        public bool IsDefault { get; private set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}