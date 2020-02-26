using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.Common.Enums;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }



        public async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInOrderAsync(Expression<Func<TEntity, object>> orderBy, OrderType orderType)
        {
            if (orderType == OrderType.Ascending)
                return await _entities.OrderBy(orderBy).ToListAsync();
            else
                return await _entities.OrderByDescending(orderBy).ToListAsync();
        }




        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindInOrderAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderBy, OrderType orderType)
        {
            if (orderType == OrderType.Ascending)
                return await _entities.Where(predicate).OrderBy(orderBy).ToListAsync();
            else
                return await _entities.Where(predicate).OrderByDescending(orderBy).ToListAsync();
        }



        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.CountAsync(predicate);
        }

        

        
    }
}
