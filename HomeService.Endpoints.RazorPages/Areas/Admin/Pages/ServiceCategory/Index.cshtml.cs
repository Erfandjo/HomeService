using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.ServiceCategory
{
    // [Authorize(Roles = "Admin")]
    public class IndexModel(IServiceCategoryAppService _serviceCategoryAppService) : PageModel
    {


        public List<ServiceCategorySummaryDto> ServiceCategories { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)
        {
            ServiceCategories = await _serviceCategoryAppService.GetAll(cancellation);
        }



        public async Task<IActionResult> OnGetDeleteAsync(int id, CancellationToken cancellation)
        {
            var result = await _serviceCategoryAppService.Delete(id, cancellation);
            return RedirectToAction("OnGet");
        }
    }
}
