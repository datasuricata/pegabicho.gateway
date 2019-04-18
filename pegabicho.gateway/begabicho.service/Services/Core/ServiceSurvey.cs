using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.infra.Transaction;
using pegabicho.service.Services.Base;

namespace pegabicho.service.Services.Core
{
    public class ServiceSurvey : ServiceApp<Survey>, IServiceSurvey
    {
        public ServiceSurvey(IUnitOfWork unitOfWork,
        IRepository<Survey> repository) : base(repository, unitOfWork)
        {

        }
    }
}
