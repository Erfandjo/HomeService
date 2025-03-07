using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Users
{
    public class ChangePasswordModel(IUserAppService _userAppService) : PageModel
    {

        [BindProperty]
        public UserChangePasswordDto User { get; set; }

        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            User = await _userAppService.GetByForChangePassword(id , cancellation);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            
            await _userAppService.ChangePasswordAdmin(User , cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
