using FluentValidation;
using pegabicho.domain.Entities.Base;
using System.Collections.Generic;

namespace pegabicho.domain.Interfaces.Services.Base {
    public interface IServiceApp<T> where T : EntityBase
    {
        void UpdateValidator<V>(T obj) where V : AbstractValidator<T>;
        void RegisterValidatorMany<V>(IEnumerable<T> entities) where V : AbstractValidator<T>;
        void RegisterValidator<V>(T obj) where V : AbstractValidator<T>;
        void EntityValidtor<V>(T obj) where V : AbstractValidator<T>;
    }
}
