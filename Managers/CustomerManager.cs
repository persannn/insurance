using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    /// <summary>
    /// This should just be a child class of some BaseManager class, which would be a general imple-
    /// mentation of a IBaseManager interface. When these are completed I'll rewrite this file too.
    /// </summary>
    /// <param name="customerRepository">an instance of</param>
    /// <param name="addressRepository"></param>
    /// <param name="mapper"></param>
    public class CustomerManager : BaseManager<Customer, CustomerViewModel>
    {
        public CustomerManager(ICustomerRepository Repository, IMapper Mapper)
            : base(Repository, Mapper)
        { }

        /// <summary>
        /// Method that returns a customer with the requested Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>CustomerViewModel of the desired Customer</returns>
        public async Task<CustomerViewModel?> GetById(int id, bool withDetails = false)
        {
            if (withDetails)
            {
                Customer? customerWithDetails = await Repository.GetWithDetails(id);
                return Mapper.Map<CustomerViewModel>(customerWithDetails);
            }
            Customer? customer = await Repository.GetById(id);
            return Mapper.Map<CustomerViewModel?>(customer);
        }
    }
}
