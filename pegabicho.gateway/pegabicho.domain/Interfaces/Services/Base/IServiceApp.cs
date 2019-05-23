using FluentValidation;
using pegabicho.domain.Entities.Base;
using System.Collections.Generic;

namespace pegabicho.domain.Interfaces.Services.Base {
    public interface IServiceApp<T> where T : EntityBase
    {
        void ValidUpdate<V>(T obj) where V : AbstractValidator<T>;
        void ValidManyRegisters<V>(List<T> entities) where V : AbstractValidator<T>;
        void ValidRegister<V>(T obj) where V : AbstractValidator<T>;
        void ValidEntity<V>(T obj) where V : AbstractValidator<T>;
    }
}
