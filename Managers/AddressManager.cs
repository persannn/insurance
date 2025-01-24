using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    // Should make an IAddressManager interface, and add the GetAddressByCustomerId method.
    public class AddressManager : BaseManager<Address, AddressViewModel>
    {
        public AddressManager(IAddressRepository Repository, IMapper Mapper)
            : base(Repository, Mapper)
        { }

        public async Task<AddressViewModel?> GetByCustomerId(int id)
        {
            List<Address> addresses = await Repository.GetAll();
            Address address = (from a in addresses
                               where a.CustomerId == id
                               select a).First();
            return Mapper.Map<AddressViewModel?>(address);
        }
    }
}
