using Candidate_BussinessObjects.Models;
using Candidate_DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public async Task<List<CandidateProfile>> SearchCandidatesAsync(string fullname, DateTime? birthday)
            => await CandidateProfileDAO.Instance.SearchCandidatesAsync(fullname, birthday);

        public async Task<PaginatedList<CandidateProfile>> GetCandidatesAsync(int pageIndex, int pageSize)
            => await CandidateProfileDAO.Instance.GetCandidatesAsync(pageIndex, pageSize);

        public async Task<bool> AddCandidateProfileAsync(CandidateProfile profile)
            => await CandidateProfileDAO.Instance.AddCandidateProfileAsync(profile);

        public async Task<CandidateProfile> GetCandidateProfileAsync(string id)
            => await CandidateProfileDAO.Instance.GetCandidateProfileByIdAsync(id);

        public async Task<List<CandidateProfile>> GetCandidateProfilesAsync()
            => await CandidateProfileDAO.Instance.GetCandidateProfilesAsync();

        public async Task<bool> RemoveCandidateProfileAsync(string profileid)
            => await CandidateProfileDAO.Instance.DeleteCandidateProfileAsync(profileid);

        public async Task<bool> UpdateCandidateProfileAsync(CandidateProfile profile)
            => await CandidateProfileDAO.Instance.UpdateCandidateProfileAsync(profile);
    }
}
