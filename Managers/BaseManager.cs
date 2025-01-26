using AutoMapper;
using Insurance_Final_Version.Interfaces;

namespace Insurance_Final_Version.Managers
{
    /// <summary>
    /// Generalized BaseManager class that contains generalized implementations of all
    /// methods the manager classes have in common.
    /// </summary>
    /// <typeparam name="TEntity">Entity in the database - Customer, Address or Insurance.</typeparam>
    /// <typeparam name="TViewModel">ViewModel of the corresponding entity.</typeparam>
    public class BaseManager<TEntity, TViewModel> : IBaseManager<TEntity, TViewModel>
        where TEntity : class, IViewModelable where TViewModel : class, IViewModelable
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public IBaseRepository<TEntity> Repository => _baseRepository;
        public IMapper Mapper => _mapper;

        /// <summary>
        /// Constructor of BaseManager
        /// </summary>
        /// <param name="baseRepository"></param>
        /// <param name="mapper"></param>
        public BaseManager(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Method that takes a TViewModel object, maps it on a TEntity object,
        /// and inserts that into the database.
        /// </summary>
        /// <param name="viewModel">ViewModel of the entity to be inserted.</param>
        /// <returns>ViewModel of the newly inserted entity.</returns>
        public virtual async Task<TViewModel?> Add(TViewModel viewModel)
        {
            TEntity entity = Mapper.Map<TEntity>(viewModel);
            TEntity addedEntity = await Repository.Insert(entity);
            return Mapper.Map<TViewModel>(addedEntity);
        }

        /// <summary>
        /// Returns a list of ViewModels based on all objects
        /// of type TEntity from the database.
        /// </summary>
        /// <returns>A list of ViewModels based on all objects of type TEntity from the database.</returns>
        public virtual async Task<List<TViewModel>> GetAll()
        {
            List<TEntity> entities = await Repository.GetAll();
            return Mapper.Map<List<TViewModel>>(entities);
        }

        /// <summary>
        /// Returns a TViewModel of a TEntity object with the corresponding ID.
        /// If there's no such object in the database, returns null.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>TViewModel of the entity, or null if not found.</returns>
        public virtual async Task<TViewModel?> GetById(int id)
        {
            TEntity? entity = await Repository.GetById(id);
            return Mapper.Map<TViewModel>(entity);

        }

        /// <summary>
        /// Returns a list of TViewModels of TEntity objects where the CustomerId matches the passed ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<TViewModel></returns>
        public virtual async Task<List<TViewModel>> GetByCustomerId(int id)
        {
            List<TEntity> entities = await Repository.GetByCustomerId(id);
            return Mapper.Map<List<TViewModel>>(entities);
        }

        /// <summary>
        /// Removes an entity of type TEntity with the corresponding ID from the database.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>'true' if successfully removed, 'false' if not found.</returns>
        public virtual async Task<bool> RemoveWithId(int id)
        {
            TEntity? entity = await Repository.GetById(id);
            bool result = false;

            if(entity is not null)
            {
                await Repository.Delete(entity);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Updates entity in the database to match the ViewModel parameter.
        /// </summary>
        /// <param name="viewModel">ViewModel of the entity to be updated.</param>
        /// <returns>ViewModel of the newly updated entity.</returns>
        public virtual async Task<TViewModel?> Update(TViewModel viewModel)
        {
            TEntity entity = Mapper.Map<TEntity>(viewModel);

            try
            {
                TEntity updatedEntity = await Repository.Update(entity);
                return Mapper.Map<TViewModel>(updatedEntity);
            }
            catch (InvalidOperationException)
            {
                if (!await Repository.ExistsWithId(entity.Id))
                    return null;
                throw;
            }
        }
    }
}
