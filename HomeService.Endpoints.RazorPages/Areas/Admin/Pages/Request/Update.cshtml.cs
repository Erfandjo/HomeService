using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Request
{

    public class UpdateModel(IRequestAppService _requestAppService) : PageModel
    {
        [BindProperty]
        public RequestUpdateDto Request { get; set; }

        

        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            Request = await _requestAppService.GetByIdForUpdate(id, cancellation);
            
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            await _requestAppService.Update(Request, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
