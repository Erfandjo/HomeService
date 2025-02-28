using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(ICityAppService _cityAppService, IUserAppService _userAppService) : PageModel
    {


        [BindProperty]
        public UserCreateDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        [BindProperty]
        public IdentityResult Result { get; set; }


        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Cities = await _cityAppService.GetAll(cancellationToken);
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken )
        {
            Result = await _userAppService.Register(User, cancellationToken);
            if (!Result.Succeeded)
            {
                Cities = await _cityAppService.GetAll(cancellationToken);
                return Page();
            }
            return RedirectToPage("Index");

        }
    }
}
