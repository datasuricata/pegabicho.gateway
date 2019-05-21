using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Entities.Core.Orders;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Travel;
using System;

namespace pegabicho.service.Services.Core {
    public class ServiceOrder : ServiceApp<Order>, IServiceOrder {
        public ServiceOrder(IServiceProvider provider) : base(provider) {
        }


        public void AddTravel(OrderRequest request) {
            try {
                ValidRegister<OrderValidator>(new Order(request.Type, request.ClientId));

            } catch (Exception e) {
                Notifier.AddException<ServiceTravel>("Não foi possivel completar sua solicitação, tente novamente.", e);
            }
        }

        public void DesigneProvider(OrderRequest request) {
            try {

                var order = repository.GetById(request.Id);
                if (order is null)
                    Notifier.Add<ServiceOrder>("Ordem de serviço não localizada.");



            } catch (Exception e) {
                Notifier.AddException<ServiceTravel>("Erro ao designar um prestador a ordem de serviço, tente novamente.", e);
            }
        }
    }
}
