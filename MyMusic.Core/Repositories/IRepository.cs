﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyMusic.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicat);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicat);
        Task<TEntity> AddAsync(TEntity etntiy);
        Task AddRangeAsync(IEnumerable< TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable< TEntity>  entities);
    }
}
