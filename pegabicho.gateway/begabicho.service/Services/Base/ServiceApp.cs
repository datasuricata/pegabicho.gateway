using FluentValidation;
using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.domain.Interfaces.Services.Base;
using pegabicho.domain.Interfaces.Services.Events;
using pegabicho.infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pegabicho.service.Services.Base {
    public class ServiceApp<T> : ServiceBase, IServiceApp<T> where T : EntityBase {

        #region [ attributes ]

        protected readonly IRepository<T> repository;

        public ServiceApp(IServiceProvider provider) : base(provider) {
            this.repository = (IRepository<T>)provider.GetService(typeof(IRepository<T>));
        }

        #endregion

        #region [ ctor ]

        #endregion

        #region [ persistance ]

        public void UpdateValidator<V>(T obj) where V : AbstractValidator<T> {
            Validate(obj, Activator.CreateInstance<V>());
          //  repository.Update(obj);
        }

        public void RegisterValidatorMany<V>(IEnumerable<T> entities) where V : AbstractValidator<T> {
            ValidateList(entities, Activator.CreateInstance<V>());
         //   repository.RegisterList(entities);
        }

        public void RegisterValidator<V>(T obj) where V : AbstractValidator<T> {
            Validate(obj, Activator.CreateInstance<V>());
         //   repository.Register(obj);
        }

        public void EntityValidtor<V>(T obj) where V : AbstractValidator<T> {
            Validate(obj, Activator.CreateInstance<V>());
        }

        #endregion

        #region [ validator ]

        private void Validate(T obj, AbstractValidator<T> validator) {
            if (obj == null)
                throw new Exception("No object call.");

            validator.ValidateAndThrow(obj);
        }

        private void ValidateList(IEnumerable<T> obj, AbstractValidator<T> validator) {
            if (!obj.Any())
                throw new Exception("No object call.");

            foreach (var x in obj) {
                if (x == null)
                    throw new Exception("No object call.");

                validator.ValidateAndThrow(x);
            }
        }

        #endregion
    }
}
