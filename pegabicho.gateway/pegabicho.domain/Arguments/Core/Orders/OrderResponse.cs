using pegabicho.domain.Entities.Core.Orders;
using pegabicho.domain.Interfaces.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace pegabicho.domain.Arguments.Core.Orders {
    public class OrderResponse : IResponse {
        public string Token { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Client { get; set; }
        public string ClientId { get; set; }
        public string Provider { get; set; }
        public string ProviderId { get; set; }
        public string DateDue { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }

        public static explicit operator OrderResponse(Order v) {
            return v == null ? null : new OrderResponse {
                Id = v.Id,
                Token = v.Token,
                ClientId = v.ClientId,
                ProviderId = v.ProviderId,
                Client = v.Client?.ToString(),
                Provider = v.Provider?.ToString(),
                CreatedAt = v.CreatedAt?.ToString("dd/MM/yyyy HH:mm"),
                DateDue = v.DateDue?.ToString("dd/MM/yyyy"),
                Status = Helpers.EnumUteis.EnumDisplay(v.Status),
                Type = Helpers.EnumUteis.EnumDisplay(v.Type),
            };
        }
    }
}
