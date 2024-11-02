using Candidate_BussinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IJobPostingRepo
    {
        Task<JobPosting> GetJobPostingAsync(string id);
        Task<IEnumerable<JobPosting>> GetJobPostingsAsync();
        Task<bool> CreateJobPostingAsync(JobPosting profile);
        Task<bool> DeleteJobPostingAsync(string profileid);
        Task<bool> UpdateJobPostingAsync(JobPosting profile);
    }
}
