using Newtonsoft.Json;
using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Orders {
    public class OrderRequest : IRequest {
        public string Id { get; set; }
        [JsonIgnore]
        public string ClientId { get; set; }
        [JsonIgnore]
        public string ProviderId { get; set; }
        public OrderType Type { get; set; }
    }
}