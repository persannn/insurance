using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    public class CustomerManager : BaseManager<Customer, CustomerViewModel>
    {
        public CustomerManager(ICustomerRepository Repository, IMapper Mapper)
            : base(Repository, Mapper)
        { }
    }
}
