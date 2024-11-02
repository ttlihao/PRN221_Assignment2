using Candidate_BussinessObjects.Models;
using Candidate_Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class HRAccountService : IHRAccountService
    {
        private readonly IHRAccountRepo hrAccountRepo;

        public HRAccountService(IHRAccountRepo hrAccountRepo)
        {
            this.hrAccountRepo = hrAccountRepo;
        }

        public async Task<Hraccount> GetHraccountByEmailAsync(string email)
            => await hrAccountRepo.GetHraccountByEmailAsync(email);

        public async Task<List<Hraccount>> GetHraccountsAsync()
            => await hrAccountRepo.GetHraccountsAsync();
    }
}
