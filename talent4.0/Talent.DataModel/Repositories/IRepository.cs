using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.Common.Enums;

namespace Talent.DataModel.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the element by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Gets all the elements
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();


        /// <summary>
        /// Gets all the elements ordered by supplied property and order type.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllInOrderAsync(Expression<Func<TEntity, object>> orderBy, OrderType orderType);



        /// <summary>
        /// Gets all the elements by predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Gets all the elements filtered by predicate then ordered by supplied property and order type.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindInOrderAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderBy, OrderType orderType);




        /// <summary>
        /// Get the first element by predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Get the first element by predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add an element.
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Add all the supplied elements.
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove an element.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove all the supplied elements
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
