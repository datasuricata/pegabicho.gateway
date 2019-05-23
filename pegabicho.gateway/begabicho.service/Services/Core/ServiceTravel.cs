using pegabicho.domain.Arguments.Core.Travels;
using pegabicho.domain.Entities.Core.Travels;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Travels;
using System;

namespace pegabicho.service.Services.Core {
    public class ServiceTravel : ServiceApp<Travel>, IServiceTravel {

        private readonly IServiceOrder serviceOrder;

        public ServiceTravel(IServiceOrder serviceOrder, IServiceProvider provider) : base(provider) {
            this.serviceOrder = serviceOrder;
        }

        public void AddTravel(TravelRequest request) {
            try {
                var order = serviceOrder.AddOrder(request.Order);
                var travel = new Travel(order.Id, request.FromLatitude, request.FromLatitude, request.ToLongitude, request.ToLatitude, request.Scheduled);
                ValidRegister<TravelValidator>(travel);
            } catch (Exception e) {
                Notifier.AddException<ServiceTravel>("Erro ao chamar uma nova viajem.", e);
            }
        }
    }
}
