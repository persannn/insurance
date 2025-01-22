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
    public class CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
    {
        private readonly ICustomerRepository customerRepository = customerRepository;
        public readonly IMapper mapper = mapper;

        /// <summary>
        /// Method that returns a customer with the requested Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>CustomerViewModel of the desired Customer</returns>
        public async Task<CustomerViewModel?> GetById(int id, bool withDetails = false)
        {
            if (withDetails)
            {
                Customer? customerWithDetails = await customerRepository.GetWithDetails(id);
                return mapper.Map<CustomerViewModel>(customerWithDetails);
            }
            Customer? customer = await customerRepository.GetById(id);
            return mapper.Map<CustomerViewModel?>(customer);
        }

        /// <summary>
        /// Returns a list of all customers in the database
        /// </summary>
        /// <returns>List<CustomerViewModel> containing all the customers in the database</returns>
        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            List<Customer> customers = await customerRepository.GetAll();
            return mapper.Map<List<CustomerViewModel>>(customers);
        }

        /// <summary>
        /// Adds a customer to the database
        /// </summary>
        /// <param name="customerViewModel">CustomerViewModel of the new customer</param>
        /// <returns>CustomerViewModel of the freshly added customer</returns>
        public async Task<CustomerViewModel> AddCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = mapper.Map<Customer>(customerViewModel);
            Customer addedCustomer = await customerRepository.Insert(customer);
            return mapper.Map<CustomerViewModel>(addedCustomer);
        }

        /// <summary>
        /// Updates the customer information according to the submitted model
        /// </summary>
        /// <param name="customerViewModel">altered CustomerViewModel</param>
        /// <returns>updated CustomerViewModel</returns>
        public async Task<CustomerViewModel?> UpdateCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = mapper.Map<Customer>(customerViewModel);

            try
            {
                Customer updatedCustomer = await customerRepository.Update(customer);
                return mapper.Map<CustomerViewModel>(updatedCustomer);
            }
            catch (InvalidOperationException)
            {
                if (!await customerRepository.ExistsWithId(customer.Id))
                    return null;

                throw;
            }
        }

        /// <summary>
        /// Removes a customer with the submitted Id from the database
        /// </summary>
        /// <param name="id">customer Id</param>
        /// <returns></returns>
        public async Task RemoveCustomerWithId(int id)
        {
            Customer? customer = await customerRepository.GetById(id);

            if (customer is not null)
                await customerRepository.Delete(customer);
        }
    }
}
