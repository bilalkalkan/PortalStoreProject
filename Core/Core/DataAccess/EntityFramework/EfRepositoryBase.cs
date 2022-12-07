using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; set; }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Where(predicate).ToList();
            }
            return Context.Set<TEntity>().ToList();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var added = Context.AddAsync(entity).Result;
            await Context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var deleted = Context.Entry(entity);
            deleted.State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updated = Context.Entry(entity);
            updated.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}