using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.domain.Interfaces.Services.Base;
using pegabicho.infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pegabicho.service.Services.Base
{
    public class ServiceApp<T> : ServiceBase, IServiceApp<T> where T : EntityBase
    {
        #region [ attributes ]

        protected readonly IRepository<T> repository;

        #endregion

        #region [ ctor ]

        public ServiceApp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        #endregion

        #region [ generic crud ]

        public bool BaseExist(Func<T, bool> where)
        {
            return repository.Exist(where);
        }

        public T BaseGetById(string id)
        {
            return repository.GetById(id);
        }

        public T BaseSoftDelete(T entity)
        {
            return repository.SoftDelete(entity);
        }

        //public T BaseUpdate<V>(T obj) where V : AbstractValidator<T>
        //{
        //    Validate(obj, Activator.CreateInstance<V>());
        //    repository.Update(obj);
        //    return obj;
        //}

        //public void BaseRegisterList<V>(IEnumerable<T> entities) where V : AbstractValidator<T>
        //{
        //    ValidateList(entities, Activator.CreateInstance<V>());
        //    repository.RegisterList(entities);
        //}

        //public void BaseRegister<V>(T obj) where V : AbstractValidator<T>
        //{
        //    Validate(obj, Activator.CreateInstance<V>());
        //    repository.Register(obj);
        //}

        public void BaseDelete(string id)
        {
            var entity = BaseGetById(id);
            if (entity != null) repository.Delete(entity);
        }

        public void BaseDeleteRage(IEnumerable<T> entities)
        {
            repository.DeleteRange(entities);
        }

        public IEnumerable<T> BaseGetAll()
        {
            return repository.ListBy(x => !x.IsDeleted).ToList();
        }

        #region [ async ]

        //public async Task BaseRegisterAsync<V>(T obj) where V : AbstractValidator<T>
        //{
        //    Validate(obj, Activator.CreateInstance<V>());
        //    await repository.RegisterAsync(obj);
        //}

        //public async Task<T> BaseGetByIdAsync(string id)
        //{
        //    return await repository.GetByIdAsync(id);
        //}

        #endregion

        #endregion

        #region [ generic validator ]

        //private void Validate(T obj, AbstractValidator<T> validator)
        //{
        //    if (obj == null)
        //        throw new Exception("No object call.");

        //    validator.ValidateAndThrow(obj);
        //}

        //private void ValidateList(IEnumerable<T> obj, AbstractValidator<T> validator)
        //{
        //    if (!obj.Any())
        //        throw new Exception("No object call.");

        //    foreach (var x in obj)
        //    {
        //        if (x == null)
        //            throw new Exception("No object call.");

        //        validator.ValidateAndThrow(x);
        //    }
        //}

        #endregion
    }
}
