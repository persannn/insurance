using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    public class AddressManager : BaseManager<Address, AddressViewModel>
    {
        public AddressManager(IAddressRepository Repository, IMapper Mapper)
            : base(Repository, Mapper)
        { }
    }
}
