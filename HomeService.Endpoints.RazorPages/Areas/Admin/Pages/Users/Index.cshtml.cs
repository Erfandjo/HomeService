using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public IndexModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [BindProperty]
        public List<UserSummaryDto> Users { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)

        {
          

            Users = await _userAppService.GetAll(cancellation);
        }


        
        public async Task<IActionResult> OnGetDeleteAsync(int id , CancellationToken cancellation)
        {
            var result = await _userAppService.Delete(id, cancellation);
            return RedirectToAction("OnGet");
        }
    }
}
