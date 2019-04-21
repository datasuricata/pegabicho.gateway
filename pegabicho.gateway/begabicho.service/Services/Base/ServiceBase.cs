using pegabicho.domain.Interfaces.Services.Base;
using pegabicho.domain.Interfaces.Services.Events;
using pegabicho.infra.Transaction;
using System;
using System.Threading.Tasks;

namespace pegabicho.service.Services.Base {
    public class ServiceBase : IServiceBase {

        #region [ attributes ]

        private readonly IUnitOfWork uow;
        private readonly IServiceProvider Provider;
        protected readonly IEventNotifier Notifier;

        #endregion

        #region [ ctor ]

        public ServiceBase(IServiceProvider provider) {
            this.Provider = provider;

            uow = (IUnitOfWork)provider.GetService(typeof(IUnitOfWork));
            Notifier = (IEventNotifier)provider.GetService(typeof(IEventNotifier));
        }

        #endregion

        #region [ persistence ]

        public async Task Commit() {
            if (Notifier.HasAny())
                return;

            await uow.Commit();
        }

        public async Task CommitForce() => await uow.Commit();

        #endregion
    }
}
