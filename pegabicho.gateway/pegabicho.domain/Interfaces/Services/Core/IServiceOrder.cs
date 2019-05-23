using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Entities.Core.Orders;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceOrder {
        Order GetById(string id);
        List<Order> ListOrders();
        List<Order> ListOrdersByStatus(OrdertStatus status);
        Order AddOrder(OrderRequest request);
        void DesignateProvider(OrderRequest request);
        void FinalizeOrder(OrderRequest request);
        void SoftDelete(string id);
    }
}
