using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.SubCategory
{
    // [Authorize(Roles = "Admin")]
    public class IndexModel(ISubCategoryAppService _subCategoryAppService) : PageModel
    {




        [BindProperty]
        public List<SubCategorySummaryDto> SubCategories { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)

        {
            SubCategories = await _subCategoryAppService.GetAll(cancellation);
        }



        public async Task<IActionResult> OnGetDeleteAsync(int id, CancellationToken cancellation)
        {
            var result = await _subCategoryAppService.Delete(id, cancellation);
            return RedirectToAction("OnGet");
        }
    }
}
