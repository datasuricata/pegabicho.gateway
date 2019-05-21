using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Travel;
using System;
using System.Collections.Generic;

namespace pegabicho.service.Services.Core {
    public class ServiceTravel : ServiceApp<Travel>, IServiceTravel {

        public ServiceTravel(IServiceProvider provider) : base(provider) {
        }

        
    }
}
