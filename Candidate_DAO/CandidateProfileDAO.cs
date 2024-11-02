using Candidate_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private readonly CandidateManagementContext _context;
        private static CandidateProfileDAO instance;

        public CandidateProfileDAO()
        {
            _context = new CandidateManagementContext();
        }

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public async Task<PaginatedList<CandidateProfile>> GetCandidatesAsync(int pageIndex, int pageSize)
        {
            var query = _context.CandidateProfiles.Include(x => x.Posting).AsNoTracking();
            return await PaginatedList<CandidateProfile>.CreateAsync(query, pageIndex, pageSize);
        }

        public async Task<List<CandidateProfile>> SearchCandidatesAsync(string fullname, DateTime? birthday)
        {
            var query = _context.CandidateProfiles.AsQueryable();

            if (!string.IsNullOrEmpty(fullname))
            {
                query = query.Where(c => c.Fullname.Contains(fullname));
            }

            if (birthday.HasValue)
            {
                query = query.Where(c => c.Birthday == birthday.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<CandidateProfile> GetCandidateProfileByIdAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return await _context.CandidateProfiles
                    .Include(x => x.Posting)
                    .FirstOrDefaultAsync(c => c.CandidateId == id);
            }
            return null;
        }

        public async Task<List<CandidateProfile>> GetCandidateProfilesAsync()
        {
            return await _context.CandidateProfiles.Include(x => x.Posting).ToListAsync();
        }

        public async Task<bool> AddCandidateProfileAsync(CandidateProfile candidateProfile)
        {
            await _context.CandidateProfiles.AddAsync(candidateProfile);
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteCandidateProfileAsync(string id)
        {
            bool isSuccess = false;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var candidate = await _context.CandidateProfiles.FirstAsync(c => c.CandidateId == id);
                    _context.CandidateProfiles.Remove(candidate);
                    var changes = await _context.SaveChangesAsync();
                    isSuccess = changes > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }

        public async Task<bool> UpdateCandidateProfileAsync(CandidateProfile profile)
        {
            bool isSuccess = false;
            var existingEntity = _context.CandidateProfiles.Local.FirstOrDefault(e => e.CandidateId == profile.CandidateId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.CandidateProfiles.Attach(profile);
            try
            {
                if (profile != null)
                {
                    _context.Attach(profile).State = EntityState.Modified;
                    var changes = await _context.SaveChangesAsync();
                    isSuccess = changes > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }
    }
}
