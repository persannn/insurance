using AutoMapper;
using Insurance_Two_Tables.Interfaces;
using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Managers
{
    // Should make an IAddressManager interface, and add the GetAddressByCustomerId method.
    public class AddressManager(IAddressRepository addressRepository, IMapper mapper)
    {
        private readonly IAddressRepository addressRepository = addressRepository;
        public readonly IMapper mapper = mapper;

        public async Task<AddressViewModel?> GetAddressById(int id)
        {
            Address? address = await addressRepository.GetById(id);
            return mapper.Map<AddressViewModel?>(address);
        }

        public async Task<List<AddressViewModel>> GetAllAddresses()
        {
            List<Address> addresses = await addressRepository.GetAll();
            return mapper.Map<List<AddressViewModel>>(addresses);
        }

        public async Task<AddressViewModel?> GetAddressByCustomerId(int id)
        {
            List<Address> addresses = await addressRepository.GetAll();
            IEnumerable<Address> address = from a in addresses
                               where a.CustomerId == id
                               select a;
            return mapper.Map<AddressViewModel?>(address);
        }

        public async Task<AddressViewModel?> AddAddress(AddressViewModel addressViewModel)
        {
            Address address = mapper.Map<Address>(addressViewModel);
            Address addedAddress = await addressRepository.Insert(address);
            return mapper.Map<AddressViewModel>(addedAddress);
        }

        public async Task<AddressViewModel?> UpdateAddress(AddressViewModel addressViewModel)
        {
            Address address = mapper.Map<Address>(addressViewModel);

            try
            {
                Address updatedAddress = await addressRepository.Update(address);
                return mapper.Map<AddressViewModel>(address);
            }
            catch (InvalidOperationException)
            {
                if (!await addressRepository.ExistsWithId(address.Id))
                    return null;

                throw;
            }
        }

        public async Task RemoveAddressWithId(int id)
        {
            Address? address = await addressRepository.GetById(id);

            if(address is not null)
                await addressRepository.Delete(address);
        }
    }
}
