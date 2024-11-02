using Candidate_BussinessObjects.Models;
using Candidate_DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public async Task<bool> CreateJobPostingAsync(JobPosting profile)
            => await JobPostingDAO.Instance.CreateJobPostingAsync(profile);

        public async Task<JobPosting> GetJobPostingAsync(string id)
            => await JobPostingDAO.Instance.GetJobPostingByIdAsync(id);

        public async Task<IEnumerable<JobPosting>> GetJobPostingsAsync()
            => await JobPostingDAO.Instance.GetJobPostingsAsync();

        public async Task<bool> DeleteJobPostingAsync(string profileid)
            => await JobPostingDAO.Instance.DeleteJobPostingAsync(profileid);

        public async Task<bool> UpdateJobPostingAsync(JobPosting jobPosting)
            => await JobPostingDAO.Instance.UpdateJobPostingAsync(jobPosting);
    }
}
