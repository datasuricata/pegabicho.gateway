using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Interfaces.Arguments.Base;
using System;

namespace pegabicho.domain.Arguments.Core.Travels {
    public class TravelRequest : IRequest {

        public double FromLongitude { get; set; }
        public double FromLatitude { get; set; }
        public double ToLongitude { get; set; }
        public double ToLatitude { get; set; }

        public DateTime? Scheduled { get; set; }

        public OrderRequest Order { get; set; }
    }
}
