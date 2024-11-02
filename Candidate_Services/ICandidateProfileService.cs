using Candidate_BussinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        Task<PaginatedList<CandidateProfile>> ListCandidatesAsync(int pageIndex, int pageSize);
        Task<CandidateProfile> GetCandidateProfileAsync(string id);
        Task<List<CandidateProfile>> GetCandidateProfilesAsync();
        Task<bool> AddCandidateProfileAsync(CandidateProfile profile);
        Task<bool> RemoveCandidateProfileAsync(string profileid);
        Task<bool> UpdateCandidateProfileAsync(CandidateProfile profile);
        Task<List<CandidateProfile>> SearchCandidatesAsync(string fullname, DateTime? birthday);
    }
}
