using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyMusic.Data.SqlServer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity etntiy)
        {
            await this.Context.Set<TEntity>().AddAsync(etntiy);
            return etntiy;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicat)
        {
            return this.Context.Set<TEntity>().Where(predicat);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.Context.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await this.Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await this.Context.Set<TEntity>().SingleOrDefaultAsync(predicat);
        }
    }
}
