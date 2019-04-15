using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Entities.Core.Users;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Ticket
{
    public class Ticket : EntityBase
    {
        public string Token { get; set; } = CustomId(6);
        public TicketType Type { get; set; }

        public virtual User Client { get; set; }
        public virtual string ClientId { get; set; }
        
        public virtual User Racer { get; set; }
        public virtual string RacerId { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual string SurveyId { get; set; }
    }
}
