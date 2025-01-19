using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    // Should make an IAddressManager interface, and add the GetAddressByCustomerId method.
    public class AddressManager(IAddressRepository addressRepository, IMapper mapper)
    {
        private readonly IAddressRepository addressRepository = addressRepository;
        public readonly IMapper mapper = mapper;

        public async Task<AddressViewModel?> GetById(int id)
        {
            Address? address = await addressRepository.GetById(id);
            return mapper.Map<AddressViewModel?>(address);
        }

        public async Task<List<AddressViewModel>> GetAll()
        {
            List<Address> addresses = await addressRepository.GetAll();
            return mapper.Map<List<AddressViewModel>>(addresses);
        }

        public async Task<AddressViewModel?> GetByCustomerId(int id)
        {
            List<Address> addresses = await addressRepository.GetAll();
            Address address = (from a in addresses
                               where a.CustomerId == id
                               select a).First();
            return mapper.Map<AddressViewModel?>(address);
        }

        public async Task<AddressViewModel?> Add(AddressViewModel addressViewModel)
        {
            Address address = mapper.Map<Address>(addressViewModel);
            Address addedAddress = await addressRepository.Insert(address);
            return mapper.Map<AddressViewModel>(addedAddress);
        }

        public async Task<AddressViewModel?> Update(AddressViewModel addressViewModel)
        {
            Address address = mapper.Map<Address>(addressViewModel);

            try
            {
                Address updatedAddress = await addressRepository.Update(address);
                return mapper.Map<AddressViewModel>(updatedAddress);
            }
            catch (InvalidOperationException)
            {
                if (!await addressRepository.ExistsWithId(address.Id))
                    return null;

                throw;
            }
        }

        public async Task RemoveWithId(int id)
        {
            Address? address = await addressRepository.GetById(id);

            if (address is not null)
                await addressRepository.Delete(address);
        }
    }
}
