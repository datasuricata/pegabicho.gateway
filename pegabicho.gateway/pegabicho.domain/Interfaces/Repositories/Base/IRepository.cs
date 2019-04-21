using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Threading.Tasks;

namespace pegabicho.domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ListBy(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetOrderBy<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> ordem, bool ascendente = true, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> List(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> ListOrderedBy<TKey>(Expression<Func<T, TKey>> ordem, bool ascendente = true, params Expression<Func<T, object>>[] includeProperties);

        T GetBy(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties);

        T GetById(string id, params Expression<Func<T, object>>[] includeProperties);

        T Update(T entity);

        T SoftDelete(T entity);

        void Delete(T entity);

        void Register(T entity);

        void RegisterList(IEnumerable<T> entities);

        void DeleteRange(IEnumerable<T> entities);

        bool Exist(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(string id);

        Task RegisterAsync(T entity);
    }
}
