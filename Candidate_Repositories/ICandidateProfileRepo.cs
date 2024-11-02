using Candidate_BussinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface ICandidateProfileRepo
    {
        Task<List<CandidateProfile>> SearchCandidatesAsync(string fullname, DateTime? birthday);
        Task<PaginatedList<CandidateProfile>> GetCandidatesAsync(int pageIndex, int pageSize);
        Task<CandidateProfile> GetCandidateProfileAsync(string id);
        Task<List<CandidateProfile>> GetCandidateProfilesAsync();
        Task<bool> AddCandidateProfileAsync(CandidateProfile profile);
        Task<bool> RemoveCandidateProfileAsync(string profileid);
        Task<bool> UpdateCandidateProfileAsync(CandidateProfile profile);
    }
}
