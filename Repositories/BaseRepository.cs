using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Insurance_Final_Version.Repositories
{
    public abstract class BaseRepository<TEntity>(ApplicationDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext dbContext = dbContext;
        protected readonly DbSet<TEntity> dbSet = dbContext.Set<TEntity>();


        public virtual async Task<TEntity?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> ExistsWithId(int id)
        {
            return await GetById(id) != null;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entry = dbSet.Add(entity);
            await dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
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

        public virtual async Task Delete(TEntity entity)
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
