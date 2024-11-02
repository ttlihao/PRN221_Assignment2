using Candidate_BussinessObjects.Models;
using Candidate_Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;

        public JobPostingService(IJobPostingRepo jobPostingRepo)
        {
            this.jobPostingRepo = jobPostingRepo;
        }

        public async Task<bool> CreateJobPostingAsync(JobPosting profile)
        {
            return await jobPostingRepo.CreateJobPostingAsync(profile);
        }

        public async Task<JobPosting> GetJobPostingAsync(string id)
        {
            return await jobPostingRepo.GetJobPostingAsync(id);
        }

        public async Task<IEnumerable<JobPosting>> GetJobPostingsAsync()
        {
            return await jobPostingRepo.GetJobPostingsAsync();
        }

        public async Task<bool> DeleteJobPostingAsync(string profileid)
        {
            return await jobPostingRepo.DeleteJobPostingAsync(profileid);
        }

        public async Task<bool> UpdateJobPostingAsync(JobPosting profile)
        {
            return await jobPostingRepo.UpdateJobPostingAsync(profile);
        }
    }
}
