namespace Insurance_Final_Version.Interfaces
{
    /// <summary>
    /// Generalized interface for a BaseRepository class, contains methods
    /// that all repositories should implement.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(int? id);
        Task<bool> ExistsWithId(int? id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity?> GetWithDetails(int? id);
    }
}
