using Microsoft.EntityFrameworkCore;
using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.infra.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace pegabicho.infra.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        #region [ attributes ]

        private readonly AppDbContext context;

        #endregion

        #region [ ctor ]

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region [ methods ]

        public virtual IQueryable<T> ListBy(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public virtual IQueryable<T> GetOrderBy<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> ordem, bool ascendente = true, params Expression<Func<T, object>>[] includeProperties)
        {
            return ascendente ? ListBy(where, includeProperties).OrderBy(ordem) : ListBy(where, includeProperties).OrderByDescending(ordem);
        }

        public virtual T GetBy(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public virtual T GetById(string id, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id == id);
            }

            return context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> List(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();

            if (includeProperties.Any())
            {
                return Include(context.Set<T>(), includeProperties);
            }

            return query;
        }

        public virtual IQueryable<T> ListOrderedBy<TKey>(Expression<Func<T, TKey>> ordem, bool ascendente = true, params Expression<Func<T, object>>[] includeProperties)
        {
            return ascendente ? List(includeProperties).OrderBy(ordem) : List(includeProperties).OrderByDescending(ordem);
        }

        public virtual void Register(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual T Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity);
            return entity;
        }

        public virtual T SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            context.Set<T>().Attach(entity);
            context.Entry(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual void RegisterList(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            context.RemoveRange(entities);
        }

        public virtual bool Exist(Func<T, bool> where)
        {
            return context.Set<T>().Any(where);
        }

        #endregion

        #region [ async ]

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task RegisterAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            await context.Set<T>().AddAsync(entity);
        }

        #endregion

        #region [ private ]

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);

            return query;
        }

        #endregion
    }
}
