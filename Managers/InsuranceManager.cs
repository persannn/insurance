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

        /// <summary>
        /// A method that takes a Customer's Id and returns a list of InsuranceViewModels
        /// corresponding to the Customer's Insurances.
        /// </summary>
        /// <param name="customerId">Customer's Id</param>
        /// <returns>list of the customer's insurances</returns>
        public async Task<List<InsuranceViewModel>> GetByCustomerId(int customerId)
        {
            List<Insurance> insurances = await Repository.GetAll();
            insurances = (from i in insurances
                          where i.CustomerId == customerId
                          select i).ToList();
            return Mapper.Map<List<InsuranceViewModel>>(insurances);
        }

    }
}
