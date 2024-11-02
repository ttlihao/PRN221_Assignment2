using Candidate_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface IHRAccountService
    {
        public Task<Hraccount> GetHraccountByEmailAsync(string email);
        public Task<List<Hraccount>> GetHraccountsAsync();
    }
}
