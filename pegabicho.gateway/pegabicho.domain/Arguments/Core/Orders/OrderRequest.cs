using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Orders {
    public class OrderRequest : IRequest {
        public OrderType Type { get; set; }
        public string ClientId { get; set; }
        public string ProviderId { get; set; }
        public string Id { get; set; }
    }
}