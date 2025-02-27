using App.Domain.AppServices.HomeService.Category;
using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.SubCategory
{

    public class UpdateModel(ISubCategoryAppService _subCategoryAppService , ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public SubCategoryUpdateDto SubCategory { get; set; }

        [BindProperty]
        public List<CategorySummaryDto> Categories { get; set; }



        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            SubCategory = await _subCategoryAppService.GetByIdForUpdate(id, cancellation);
            Categories = await _categoryAppService.GetAll(cancellation);

        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Update(SubCategory, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
