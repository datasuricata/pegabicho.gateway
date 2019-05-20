using pegabicho.domain.Arguments.Core.Travel;
using pegabicho.domain.Entities.Core.Ticket;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using System;

namespace pegabicho.service.Services.Core {
    public class ServiceTravel : ServiceApp<Ticket>, IServiceTravel {

        public ServiceTravel(IServiceProvider provider) : base(provider) {

        }

        public void AddTravel(TravelRequest request) {
            try {
                ValidRegister<>(new Ticket(request.Type, request.IsRecall, request.ClientId));

            } catch (Exception e) {
                Notifier.AddException<ServiceTravel>("Não foi possivel completar sua solicitação.", e);
            }
        }
    }
}
