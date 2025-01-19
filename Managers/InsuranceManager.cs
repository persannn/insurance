using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    public class InsuranceManager(IInsuranceRepository insuranceRepository, IMapper mapper)
    {
        private readonly IInsuranceRepository insuranceRepository = insuranceRepository;
        private readonly IMapper mapper = mapper;

        public async Task<InsuranceViewModel?> GetById(int id, bool byCustomerId = false)
        {
            Insurance? insurance = await insuranceRepository.GetById(id);

            // If the submitted Id is of the Customer instead of the Insurance, this query is executed.
            if (byCustomerId)
            {
                List<Insurance> insurances = await insuranceRepository.GetAll();
                insurance = (from i in insurances
                                       where i.CustomerId == id
                                       select i).First();
            }

            return mapper.Map<InsuranceViewModel>(insurance);
        }

        public async Task<List<InsuranceViewModel>> GetAll()
        {
            List<Insurance> insurances = await insuranceRepository.GetAll();
            return mapper.Map<List<InsuranceViewModel>>(insurances);
        }

        public async Task<InsuranceViewModel?> Add(InsuranceViewModel insuranceViewModel)
        {
            Insurance insurance = mapper.Map<Insurance>(insuranceViewModel);
            Insurance addedInsurance = await insuranceRepository.Insert(insurance);
            return mapper.Map<InsuranceViewModel>(addedInsurance);
        }

        public async Task<InsuranceViewModel?> Update(InsuranceViewModel insuranceViewModel)
        {
            Insurance insurance = mapper.Map<Insurance>(insuranceViewModel);

            try
            {
                Insurance updatedInsurance = await insuranceRepository.Update(insurance);
                return mapper.Map<InsuranceViewModel>(updatedInsurance);
            }
            catch(InvalidOperationException)
            {
                if (!await insuranceRepository.ExistsWithId(insurance.Id))
                    return null;

                throw;
            }
        }

        public async Task RemoveWithId(int id)
        {
            Insurance? insurance = await insuranceRepository.GetById(id);

            if (insurance is not null)
                await insuranceRepository.Delete(insurance);
        }
    }
}
