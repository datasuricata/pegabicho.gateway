using pegabicho.service.Events;
using pegabicho.domain.Interfaces.Services.Base;
using pegabicho.infra.Transaction;
using System;
using System.Threading.Tasks;

namespace pegabicho.service.Services.Base 
{
    public class ServiceBase : EventNotifier, IServiceBase
    {
        #region [ attributes ]

        private readonly IUnitOfWork unitOfWork;
        
        #endregion

        #region [ ctor ]

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region [ persistence ]

        public async Task Commit()
        {
            if (HasNotification())
                return;
            else
                await unitOfWork.Commit();
        }

        public async Task CommitForce() => await unitOfWork.Commit();

        #endregion

        #region [ methods ]

        /// <summary>
        /// get actual environment 
        /// </summary>
        public string CurrentAmbience
        {
            get
            {
                return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            }
        }

        #endregion
    }
}
