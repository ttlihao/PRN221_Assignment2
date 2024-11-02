using Candidate_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private readonly CandidateManagementContext _context;
        private static JobPostingDAO instance;

        public JobPostingDAO()
        {
            _context = new CandidateManagementContext();
        }

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public async Task<JobPosting> GetJobPostingByIdAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return await _context.JobPostings.FirstOrDefaultAsync(c => c.PostingId == id);
            }
            return null;
        }

        public async Task<IEnumerable<JobPosting>> GetJobPostingsAsync()
        {
            return await _context.JobPostings.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteJobPostingAsync(string id)
        {
            var jobPosting = await _context.JobPostings.FirstOrDefaultAsync(c => c.PostingId == id);
            if (jobPosting != null)
            {
                _context.JobPostings.Remove(jobPosting);
                var changes = await _context.SaveChangesAsync();
                return changes > 0;
            }
            return false;
        }

        public async Task<bool> CreateJobPostingAsync(JobPosting jobPosting)
        {
            if (jobPosting == null)
            {
                return false;
            }

            await _context.JobPostings.AddAsync(jobPosting);
            var changes = await _context.SaveChangesAsync(); // Save changes to the database

            return changes > 0;
        }

        public async Task<bool> UpdateJobPostingAsync(JobPosting jobPostingDTO)
        {
            if (jobPostingDTO == null || string.IsNullOrEmpty(jobPostingDTO.PostingId))
            {
                return false;
            }

            var jobPosting = await _context.JobPostings.FirstOrDefaultAsync(c => c.PostingId == jobPostingDTO.PostingId);
            if (jobPosting == null)
            {
                return false;
            }

            jobPosting.JobPostingTitle = jobPostingDTO.JobPostingTitle;
            jobPosting.Description = jobPostingDTO.Description;
            jobPosting.PostedDate = jobPostingDTO.PostedDate;

            _context.JobPostings.Update(jobPosting);
            var changes = await _context.SaveChangesAsync(); // Save changes to the database

            return changes > 0;
        }
    }
}
