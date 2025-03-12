using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Account.Pages
{
    public class RegisterModel(ICityAppService _cityAppService, IUserAppService _userAppService) : PageModel
    {


        [BindProperty]
        public UserCreateDto User { get; set; }

        public IdentityResult Result { get; set; }


        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
          
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                Result = await _userAppService.Register(User, cancellationToken);
                if (Result.Succeeded)
                {
                    return RedirectToPage("Login");
                }
            }
            return Page();
            
        }



    }
}
