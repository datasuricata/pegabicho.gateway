using pegabicho.domain.Entities.Core.Ticket;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using System;

namespace pegabicho.service.Services.Core {
    public class ServiceTravel : ServiceApp<Ticket>, IServiceTravel {

        public ServiceTravel(IServiceProvider provider) : base(provider) {
        }
    }
}
