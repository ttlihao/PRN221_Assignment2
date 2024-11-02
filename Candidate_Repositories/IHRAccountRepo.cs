using Candidate_BussinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IHRAccountRepo
    {
        Task<Hraccount> GetHraccountByEmailAsync(string email);
        Task<List<Hraccount>> GetHraccountsAsync();
    }
}
