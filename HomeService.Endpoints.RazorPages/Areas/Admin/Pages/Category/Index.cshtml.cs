using App.Domain.Core.HomeService.CategoryEntity.AppService.EntityFramework;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(ICategoryAppService _categoryAppService) : PageModel
    {
      

    

        [BindProperty]
        public List<CategorySummaryDto> Categories { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)

        {
            Categories = await _categoryAppService.GetAll(cancellation);
        }



        public async Task<IActionResult> OnGetDeleteAsync(int id, CancellationToken cancellation)
        {
            var result = await _categoryAppService.Delete(id, cancellation);
            return RedirectToAction("OnGet");
        }
    }
}
