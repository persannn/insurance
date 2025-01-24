using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Insurance_Final_Version.Repositories
{
    /// <summary>
    /// Abstract repository class that implements IBaseRepository, all the repository classes in this project inherit its methods.
    /// </summary>
    /// <typeparam name="TEntity">Generic object of type 'class'.</typeparam>
    /// <param name="dbContext">Database context, in our case it's always ApplicationDbContext.</param>
    public abstract class BaseRepository<TEntity>(ApplicationDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Database context, in our case it's always ApplicationDbContext.
        /// </summary>
        protected readonly ApplicationDbContext dbContext = dbContext;
        /// <summary>
        /// DbSet containing only the entity type that the repository is responsible for - Customer, Address or Insurance.
        /// </summary>
        protected readonly DbSet<TEntity> dbSet = dbContext.Set<TEntity>();

        /// <summary>
        /// Returns an instance of TEntity with the passed ID.
        /// </summary>
        /// <param name="id">ID of the desired TEntity</param>
        /// <returns>TEntity with the passed id, or null if not found.</returns>
        public virtual async Task<TEntity?> GetById(int? id)
        {
            return await dbSet.FindAsync(id);
        }
        /// <summary>
        /// Returns 'true' if TEntity with the submitted ID is in the database, 'false' if not.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>'true' if TEntity with the submitted ID is in the database, 'false' if not.</returns>
        public virtual async Task<bool> ExistsWithId(int? id)
        {
            return await GetById(id) != null;
        }
        /// <summary>
        /// Returns a list of all objects of type TEntity in the database.
        /// </summary>
        /// <returns>A list of all objects of type TEntity in the database.</returns>
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
        /// <summary>
        /// Inserts an object of type TEntity into the database.
        /// </summary>
        /// <param name="entity">Instance of TENtity to be inserted into the database.</param>
        /// <returns>TEntity that was just inserted into the database.</returns>
        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entry = dbSet.Add(entity);
            await dbContext.SaveChangesAsync();
            return entry.Entity;
        }
        /// <summary>
        /// Updates an entity of type TEntity to match the passed entity.
        /// </summary>
        /// <param name="entity">TEntity object according to which the database will be updated.</param>
        /// <returns>TEntity object that was just updated.</returns>
        /// <exception cref="InvalidOperationException"></exception>
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
        /// <summary>
        /// Deletes an object of type TEntity from the database.
        /// </summary>
        /// <param name="entity">Entity to be removed from the database.</param>
        /// <returns></returns>
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
