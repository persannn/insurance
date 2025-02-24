using AutoMapper;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressViewModel>();
            CreateMap<AddressViewModel, Address>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<Insurance, InsuranceViewModel>();
            CreateMap<InsuranceViewModel, Insurance>();
        }
    }
}
