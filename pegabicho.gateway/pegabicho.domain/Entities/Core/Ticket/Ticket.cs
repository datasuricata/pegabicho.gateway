using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Entities.Core.Users;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Ticket {
    public class Ticket : EntityBase {

        #region [ attributes ]

        public string Token { get; private set; } = CustomHash(6);

        public TicketStatus Status {
            get {
                if (DateDue.HasValue)
                    return TicketStatus.Processed;

                if (ReCall > 0)
                    return TicketStatus.ReCall;

                if (!string.IsNullOrEmpty(ProviderId))
                    return TicketStatus.Designed;

                return TicketStatus.Waiting;
            }
        }

        public TicketType Type { get; private set; }

        public ModuleService Service { get; set; }

        public int ReCall { get; set; }

        public virtual User Client { get; private set; }
        public virtual string ClientId { get; private set; }

        public virtual User Provider { get; private set; }
        public virtual string ProviderId { get; private set; }

        public virtual Survey Survey { get; private set; }
        public virtual string SurveyId { get; private set; }

        public DateTimeOffset? DateDue { get; private set; }

        #endregion

        #region [ ctor ]

        protected Ticket() {

        }

        public Ticket(TicketType type, bool isReCall, string clientId) {
            Type = type;
            ClientId = clientId;

            if (isReCall)
                ReCall++;
        }

        public void DesigneRacer(string racerId) {
            ProviderId = racerId;
        }

        #endregion
    }
}
