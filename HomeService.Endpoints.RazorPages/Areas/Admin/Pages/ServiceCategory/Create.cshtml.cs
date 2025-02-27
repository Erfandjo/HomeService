using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.ServiceCategory
{
    public class CreateModel(IServiceCategoryAppService _serviceCategoryAppService, ISubCategoryAppService _subCategoryAppService) : PageModel
    {


        [BindProperty]
        public ServiceCategoryCreateDto ServiceCategory { get; set; }

        [BindProperty]
        public List<SubCategorySummaryDto> SubCategories { get; set; }


        //public async Task OnGetAsync(CancellationToken cancellationToken)
        //{

        //}
        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            SubCategories = await _subCategoryAppService.GetAll(cancellationToken);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            await _serviceCategoryAppService.Add(ServiceCategory , cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
