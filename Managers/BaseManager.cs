using AutoMapper;
using Insurance_Final_Version.Interfaces;

namespace Insurance_Final_Version.Managers
{
    public class BaseManager<TEntity>(IBaseRepository<TEntity> baseRepository, IMapper mapper) where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository = baseRepository;
        private readonly IMapper mapper = mapper;


    }
}
