using Candidate_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CandidateManageWebsite.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        private readonly IHRAccountService _hRAccountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IHRAccountService hRAccountService, IHttpContextAccessor httpContextAccessor)
        {
            _hRAccountService = hRAccountService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _hRAccountService.GetHraccountByEmailAsync(UserName);
            if (response == null || response.Password != Password || response.MemberRole != 2)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Save login info in session
            _httpContextAccessor.HttpContext.Session.SetString("UserName", UserName);
            _httpContextAccessor.HttpContext.Session.SetString("UserRole", response.MemberRole.ToString());

            return RedirectToPage("/CandidateProfilePage/Index");
        }
    }
}
