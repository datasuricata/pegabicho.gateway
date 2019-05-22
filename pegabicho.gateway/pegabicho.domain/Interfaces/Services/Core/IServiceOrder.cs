using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Entities.Core.Orders;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceOrder {
        Order AddOrder(OrderRequest request);

        void DesignateProvider(OrderRequest request);
        void FinalizeOrder(OrderRequest request);
    }
}
