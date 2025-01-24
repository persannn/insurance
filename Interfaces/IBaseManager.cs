namespace Insurance_Final_Version.Interfaces
{
    // Right now this interface isn't implemented yet.
    /// <summary>
    /// Interface for the BaseManager class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseManager<TEntity, TViewModel> where TEntity : class where TViewModel : class, IViewModelable
    {
        Task<TViewModel?> GetById(int id);
        Task<List<TViewModel>> GetAll();
        Task<TViewModel?> Add(TViewModel viewModel);
        Task<TViewModel?> Update(TViewModel viewModel);
        Task<bool> RemoveWithId(int id);
    }
}
