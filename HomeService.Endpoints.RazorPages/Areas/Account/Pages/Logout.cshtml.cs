using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Account.Pages
{
    public class LogoutModel(IUserAppService _userAppService) : PageModel
    {
        

        public async Task<IActionResult> OnGet(CancellationToken cancellation)
        {
            await _userAppService.LogOut(cancellation);

            return RedirectToPage("Index");
        }

    }
}
