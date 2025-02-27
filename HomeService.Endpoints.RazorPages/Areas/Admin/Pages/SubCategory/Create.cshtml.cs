using App.Domain.AppServices.HomeService.City;
using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Domain.Core.HomeService.CategoryEntity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Domain.Core.HomeService.SubCategoryEntity.Entities;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.SubCategory
{
    public class CreateModel(ISubCategoryAppService _subCategoryAppService , ICategoryAppService _categoryAppService) : PageModel
    {


        [BindProperty]
        public SubCategoryCreateDto SubCategory { get; set; }

        [BindProperty]
        public List<CategorySummaryDto> Categories { get; set; }


        //public async Task OnGetAsync(CancellationToken cancellationToken)
        //{

        //}
        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Categories = await _categoryAppService.GetAll(cancellationToken);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Add(SubCategory, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
