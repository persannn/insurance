namespace Insurance_Final_Version.Interfaces
{
    // Right now this interface isn't implemented yet.
    /// <summary>
    /// Interface for the BaseManager class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseManager<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity?> Add(TEntity entity);
        Task<TEntity?> Update(TEntity entity);
        Task<TEntity?> Delete(int id);
    }
}
