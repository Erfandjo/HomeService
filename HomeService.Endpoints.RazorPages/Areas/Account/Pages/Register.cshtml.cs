using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Account.Pages
{
    public class RegisterModel(ICityAppService _cityAppService, IUserAppService _userAppService) : PageModel
    {


        [BindProperty]
        public UserCreateDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Cities = await _cityAppService.GetAll(cancellationToken);
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _userAppService.Register(User, cancellationToken);
            return RedirectToPage("Index");
        }



    }
}
