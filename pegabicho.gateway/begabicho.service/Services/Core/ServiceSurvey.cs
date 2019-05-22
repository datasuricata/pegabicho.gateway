using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using System;

namespace pegabicho.service.Services.Core {
    public class ServiceSurvey : ServiceApp<Survey>, IServiceSurvey {
        public ServiceSurvey(IServiceProvider provider) : base(provider) {
        }
    }
}
