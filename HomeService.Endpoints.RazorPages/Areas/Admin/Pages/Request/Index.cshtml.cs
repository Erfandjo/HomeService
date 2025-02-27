using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Request
{
    // [Authorize(Roles = "Admin")]
    public class IndexModel(IRequestAppService _requestAppService) : PageModel
    {
      

    

        [BindProperty]
        public List<RequestSummaryDto> Requests { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)

        {
            Requests = await _requestAppService.GetAll(cancellation);
        }



        //public async Task<IActionResult> OnGetDeleteAsync(int id, CancellationToken cancellation)
        //{
        //    var result = await _categoryAppService.Delete(id, cancellation);
        //    return RedirectToAction("OnGet");
        //}
    }
}
