namespace Insurance_Final_Version.Interfaces
{
    /// <summary>
    /// Generalized interface for a BaseRepository class, contains methods
    /// that all repositories should implement.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Returns an instance of TEntity with the passed ID.
        /// </summary>
        /// <param name="id">ID of the desired TEntity</param>
        /// <returns>TEntity with the passed id, or null if not found.</returns>
        Task<TEntity?> GetById(int? id);
        /// <summary>
        /// Returns an instance of TEntity where the CustomerId matches the passed ID.
        /// If the entity is a Customer, it will instead return the Customer with the passed ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>TEntity entity</returns>
        Task<List<TEntity>> GetByCustomerId(int? id);
        /// <summary>
        /// Returns 'true' if TEntity with the submitted ID is in the database, 'false' if not.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>'true' if TEntity with the submitted ID is in the database, 'false' if not.</returns>
        Task<bool> ExistsWithId(int? id);
        /// <summary>
        /// Returns a list of all objects of type TEntity in the database.
        /// </summary>
        /// <returns>A list of all objects of type TEntity in the database.</returns>
        Task<List<TEntity>> GetAll();
        /// <summary>
        /// Inserts an object of type TEntity into the database.
        /// </summary>
        /// <param name="entity">Instance of TENtity to be inserted into the database.</param>
        /// <returns>TEntity that was just inserted into the database.</returns>
        Task<TEntity> Insert(TEntity entity);
        /// <summary>
        /// Updates an entity of type TEntity to match the passed entity.
        /// </summary>
        /// <param name="entity">TEntity object according to which the database will be updated.</param>
        /// <returns>TEntity object that was just updated.</returns>
        Task<TEntity> Update(TEntity entity);
        /// <summary>
        /// Deletes an object of type TEntity from the database.
        /// </summary>
        /// <param name="entity">Entity to be removed from the database.</param>
        /// <returns></returns>
        Task Delete(TEntity entity);
    }
}
