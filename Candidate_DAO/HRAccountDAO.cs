using Candidate_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private readonly CandidateManagementContext context;
        private static HRAccountDAO instance;

        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public async Task<Hraccount> GetHraccountByEmailAsync(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return await context.Hraccounts.FirstOrDefaultAsync(c => c.Email == email);
            }
            return null;
        }

        public async Task<List<Hraccount>> GetHraccountsAsync()
        {
            return await context.Hraccounts.ToListAsync();
        }
    }
}
