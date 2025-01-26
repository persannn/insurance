using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    public class InsuranceManager : BaseManager<Insurance, InsuranceViewModel>
    {
        public InsuranceManager(IInsuranceRepository Repository, IMapper Mapper)
            : base(Repository, Mapper)
        { }
    }
}
