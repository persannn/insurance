using AutoMapper;
using Insurance_Final_Version.Interfaces;

namespace Insurance_Final_Version.Managers
{
    public class BaseManager<TEntity, TViewModel> : IBaseManager<TEntity, TViewModel>
        where TEntity : class, IViewModelable where TViewModel : class, IViewModelable
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public IBaseRepository<TEntity> Repository => _baseRepository;
        public IMapper Mapper => _mapper;

        public BaseManager(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel?> Add(TViewModel viewModel)
        {
            TEntity entity = Mapper.Map<TEntity>(viewModel);
            TEntity addedEntity = await Repository.Insert(entity);
            return Mapper.Map<TViewModel>(addedEntity);
        }

        public virtual async Task<List<TViewModel>> GetAll()
        {
            List<TEntity> entities = await Repository.GetAll();
            return Mapper.Map<List<TViewModel>>(entities);
        }

        public virtual Task<TViewModel?> GetById(int id)
        {
            throw new NotImplementedException();
        }

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
