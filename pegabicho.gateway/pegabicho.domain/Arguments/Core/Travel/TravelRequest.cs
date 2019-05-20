using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Travel {
    public class TravelRequest : IRequest {
        public TicketType Type { get; set; }
        public string ClientId { get; set; }
        public string ProviderId { get; set; }
        public bool IsRecall { get; set; }
    }
}