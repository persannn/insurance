using AutoMapper;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Managers
{
    public class InsuranceManager(IInsuranceRepository insuranceRepository, IMapper mapper)
    {
        private readonly IInsuranceRepository insuranceRepository = insuranceRepository;
        public readonly IMapper mapper = mapper;

        public async Task<InsuranceViewModel?> GetById(int id)
        {
            Insurance? insurance = await insuranceRepository.GetById(id);
            return mapper.Map<InsuranceViewModel>(insurance);
        }

        /// <summary>
        /// A method that takes a Customer's Id and returns a list of InsuranceViewModels
        /// corresponding to the Customer's Insurances.
        /// </summary>
        /// <param name="customerId">Customer's Id</param>
        /// <returns>list of the customer's insurances</returns>
        public async Task<List<InsuranceViewModel>> GetByCustomerId(int customerId)
        {
            List<Insurance> insurances = await insuranceRepository.GetAll();
            insurances = (from i in insurances
                          where i.CustomerId == customerId
                          select i).ToList();
            return mapper.Map<List<InsuranceViewModel>>(insurances);
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
