﻿using AutoMapper;
using Insurance_Two_Tables.Interfaces;
using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Managers
{
    public class CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
    {
        private readonly ICustomerRepository customerRepository = customerRepository;
        private readonly IMapper mapper = mapper;

        public async Task<CustomerViewModel?> GetCustomerById(int id)
        {
            Customer? customer = await customerRepository.GetById(id);
            return mapper.Map<CustomerViewModel?>(customer);
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            List<Customer> customers = await customerRepository.GetAll();
            return mapper.Map<List<CustomerViewModel>>(customers);
        }

        public async Task<CustomerViewModel?> AddCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = mapper.Map<Customer>(customerViewModel);
            Customer addedCustomer = await customerRepository.Insert(customer);
            return mapper.Map<CustomerViewModel>(addedCustomer);
        }

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

        public async Task RemoveCustomerWithId(int id)
        {
            Customer? customer = await customerRepository.GetById(id);

            if(customer is not null)
                await customerRepository.Delete(customer);
        }
    }
}
