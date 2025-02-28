using App.Domain.AppServices.HomeService.City;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Request
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel(IRequestAppService _requestAppService) : PageModel
    {
        [BindProperty]
        public RequestUpdateDto Request { get; set; }

        //[BindProperty]
        //public Result Result { get; set; }



        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            Request = await _requestAppService.GetByIdForUpdate(id, cancellation);
            
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            var u = await _requestAppService.Update(Request, cancellationToken);
            //if (!Result.IsSucces)
            //{
            //    return Page();
            //}
            return RedirectToPage("Index");
        }
    }
}
