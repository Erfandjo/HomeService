using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel(ICityAppService _cityAppService, IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public UserUpdateDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            User = await _userAppService.GetByIdForUpdate(id, cancellation);
            Cities = await _cityAppService.GetAll(cancellation);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            await _userAppService.Update(User, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
