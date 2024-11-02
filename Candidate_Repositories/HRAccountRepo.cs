using Candidate_BussinessObjects.Models;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public async Task<Hraccount> GetHraccountByEmailAsync(string email) => await HRAccountDAO.Instance.GetHraccountByEmailAsync(email);

        public async Task<List<Hraccount>> GetHraccountsAsync() => await HRAccountDAO.Instance.GetHraccountsAsync();
    }
}
