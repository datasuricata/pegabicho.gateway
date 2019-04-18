using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Entities.Core.Users;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Ticket
{
    public class Ticket : EntityBase
    {
        public string Token { get; private set; } = CustomHash(6);
        public TicketType Type { get; private set; }

        public virtual User Client { get; private set; }
        public virtual string ClientId { get; private set; }
        
        public virtual User Racer { get; private set; }
        public virtual string RacerId { get; private set; }

        public virtual Survey Survey { get; private set; }
        public virtual string SurveyId { get; private set; }

        
    }
}
