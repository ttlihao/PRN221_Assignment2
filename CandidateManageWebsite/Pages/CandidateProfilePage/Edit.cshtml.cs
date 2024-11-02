using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObjects.Models;
using Candidate_Services;

namespace CandidateManageWebsite.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService jobPostingService;
        private readonly ICandidateProfileService candidateProfileService;

        public EditModel(IJobPostingService _jobPostingService, ICandidateProfileService _candidateProfileService)
        {
            jobPostingService = _jobPostingService;
            candidateProfileService = _candidateProfileService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || await candidateProfileService.GetCandidateProfilesAsync() == null)
            {
                return NotFound();
            }

            var candidateprofile =  await candidateProfileService.GetCandidateProfileAsync(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
           ViewData["PostingId"] = new SelectList(await jobPostingService.GetJobPostingsAsync(), "PostingId", "JobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await candidateProfileService.UpdateCandidateProfileAsync(CandidateProfile);

            return RedirectToPage("./Index");
        }

        private async Task<bool> CandidateProfileExists(string id)
        {
            var profile = await candidateProfileService.GetCandidateProfileAsync(id);
            return profile != null;
        }

    }
}
