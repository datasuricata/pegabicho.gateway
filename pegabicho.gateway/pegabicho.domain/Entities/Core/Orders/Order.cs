using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Users;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Orders {
    public class Order : EntityBase {

        #region [ attributes ]

        public string Token { get; private set; } = $"{CustomHash(4)}-{CustomHash(4)}";

        public OrdertStatus Status {
            get {
                if (DateDue.HasValue)
                    return OrdertStatus.Processed;

                if (!string.IsNullOrEmpty(ProviderId))
                    return OrdertStatus.Designed;

                return OrdertStatus.Waiting;
            }
        }

        public OrderType Type { get; private set; }

        public User Client { get; private set; }
        public string ClientId { get; private set; }

        public User Provider { get; private set; }
        public string ProviderId { get; private set; }

        public DateTimeOffset? DateDue { get; private set; }

        #endregion

        #region [ ctor ]

        protected Order() {

        }

        public Order(OrderType type, string clientId) {
            Type = type;
            ClientId = clientId;
        }

        public void DesigneProvider(string providerId) {
            ProviderId = providerId;
        }

        public void EndedOrder() {
            DateDue = DateTime.UtcNow;
        }

        #endregion
    }
}
