﻿using Insurance_Two_Tables.Data;
using Insurance_Two_Tables.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Insurance_Two_Tables.Repositories
{
    public abstract class BaseRepository<TEntity>(ApplicationDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext dbContext = dbContext;
        private readonly DbSet<TEntity> dbSet = dbContext.Set<TEntity>();


        public async Task<TEntity?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> ExistsWithId(int id)
        {
            return await GetById(id) != null;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entry = dbSet.Add(entity);
            await dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                EntityEntry<TEntity> entry = dbSet.Update(entity);
                await dbContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task Delete(TEntity entity)
        {
            try
            {
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                dbContext.Entry(entity).State = EntityState.Unchanged;
                throw;
            }
        }
    }
}
