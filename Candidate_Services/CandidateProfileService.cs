using Candidate_BussinessObjects.Models;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo candidateProfileRepo;
        private readonly IJobPostingRepo jobPostingRepo;

        public CandidateProfileService(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
        {
            this.candidateProfileRepo = candidateProfileRepo;
            this.jobPostingRepo = jobPostingRepo;
        }

        public async Task<bool> AddCandidateProfileAsync(CandidateProfile profile)
        {
            ValidateCandidate(profile);
            return await candidateProfileRepo.AddCandidateProfileAsync(profile);
        }

        public async Task<CandidateProfile> GetCandidateProfileAsync(string id)
        {
            return await candidateProfileRepo.GetCandidateProfileAsync(id);
        }

        public async Task<List<CandidateProfile>> GetCandidateProfilesAsync()
        {
            return await candidateProfileRepo.GetCandidateProfilesAsync();
        }

        public async Task<bool> RemoveCandidateProfileAsync(string profileid)
        {
            return await candidateProfileRepo.RemoveCandidateProfileAsync(profileid);
        }

        public async Task<bool> UpdateCandidateProfileAsync(CandidateProfile profile)
        {
            ValidateCandidate(profile);
            return await candidateProfileRepo.UpdateCandidateProfileAsync(profile);
        }

        public async Task<PaginatedList<CandidateProfile>> ListCandidatesAsync(int pageIndex, int pageSize)
        {
            return await candidateProfileRepo.GetCandidatesAsync(pageIndex, pageSize);
        }

        public async Task<List<CandidateProfile>> SearchCandidatesAsync(string fullname, DateTime? birthday)
        {
            return await candidateProfileRepo.SearchCandidatesAsync(fullname, birthday);
        }

        private void ValidateCandidate(CandidateProfile candidate)
        {
            if (string.IsNullOrWhiteSpace(candidate.Fullname) || candidate.Fullname.Length <= 12)
            {
                throw new ValidationException("Full name must be greater than 12 characters.");
            }
            if (!IsEachWordCapitalized(candidate.Fullname))
            {
                throw new ValidationException("Each word of the candidate's full name must begin with a capital letter.");
            }
            if (string.IsNullOrWhiteSpace(candidate.ProfileShortDescription) || candidate.ProfileShortDescription.Length < 12 || candidate.ProfileShortDescription.Length > 200)
            {
                throw new ValidationException("Profile description must be between 12 and 200 characters.");
            }
            if (jobPostingRepo.GetJobPostingAsync(candidate.PostingId) == null)
            {
                throw new ValidationException("A valid Job Posting must be selected.");
            }
        }

        private bool IsEachWordCapitalized(string fullName)
        {
            var words = fullName.Split(' ');
            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word) || !char.IsUpper(word[0]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
