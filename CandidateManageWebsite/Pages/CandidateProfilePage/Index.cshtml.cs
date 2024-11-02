using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObjects.Models;
using Candidate_Services;
using Microsoft.AspNetCore.Http;

namespace CandidateManageWebsite.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public IndexModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

        public PaginatedList<CandidateProfile> CandidateProfile { get; set; } = default!;
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? PageSize { get; set; } = 3;

        public async Task<IActionResult> OnGetAsync(int? pageIndex, int? pageSize)
        {
            // Check session for authentication
            var userRole = HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(userRole) || userRole != "2")
            {
                return RedirectToPage("/Index"); // Redirect to homepage if not authorized
            }

            try
            {
                PageIndex = pageIndex ?? 1;
                PageSize = pageSize ?? 3;
                var profile = await _candidateProfileService.GetCandidateProfilesAsync();
                if (PageSize == -1)
                {
                    CandidateProfile = await _candidateProfileService.ListCandidatesAsync(PageIndex, profile.Count());
                }
                else
                {
                    CandidateProfile = await _candidateProfileService.ListCandidatesAsync(PageIndex, (int)PageSize);
                }

                PageIndex = CandidateProfile.PageIndex;
                TotalPages = CandidateProfile.TotalPages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Page();
        }
    }
}
