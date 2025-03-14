using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Expert.Profile
{
    [Authorize(Roles = "Expert")]
    public class ChangePasswordModel : PageModel
    {

        private readonly IExpertAppService _expertAppService;
        public ChangePasswordModel(IExpertAppService expertAppService)
        {
            _expertAppService = expertAppService;

        }

        [BindProperty]
        public ExpertChangePasswordDto Expert { get; set; }

        [BindProperty]
        public IdentityResult Results { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)
        {
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                Expert.Id = int.Parse(UserTools.GetUserId(User.Claims));
                Results = await _expertAppService.ChangePassword(Expert, cancellationToken);
            }

            return Page();
        }
    }
}
