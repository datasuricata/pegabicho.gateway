using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace pegabicho.domain.Interfaces.Services.Base
{
    public interface IServiceApp<T> where T : EntityBase
    {
        T BaseGetById(string id);

        //T BaseUpdate<V>(T obj) where V : AbstractValidator<T>;

        IEnumerable<T> BaseGetAll();

        bool BaseExist(Func<T, bool> where);

        void BaseDelete(string id);

        void BaseDeleteRage(IEnumerable<T> entities);

        T BaseSoftDelete(T obj);

        //void BaseRegisterList<V>(IEnumerable<T> entities) where V : AbstractValidator<T>;

        //void BaseRegister<V>(T obj) where V : AbstractValidator<T>;

        //Task<T> BaseGetByIdAsync(string id);

        //Task BaseRegisterAsync<V>(T obj) where V : AbstractValidator<T>;
    }
}
