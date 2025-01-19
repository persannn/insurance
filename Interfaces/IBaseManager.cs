namespace Insurance_Final_Version.Interfaces
{
    public interface IBaseManager<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity?> Add(TEntity entity);
        Task<TEntity?> Update(TEntity entity);
        Task<TEntity?> Delete(int id);
    }
}
