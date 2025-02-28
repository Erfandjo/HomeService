using App.Domain.AppServices.HomeService.Category;
using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.ServiceCategory
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel(IServiceCategoryAppService _serviceCategoryAppService, ISubCategoryAppService _subCategoryAppService) : PageModel
    {
        [BindProperty]
        public ServiceCategoryUpdateDto ServiceCategory { get; set; }

        [BindProperty]
        public List<SubCategorySummaryDto> SubCategories { get; set; }



        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            ServiceCategory = await _serviceCategoryAppService.GetByIdForUpdate(id, cancellation);
            SubCategories = await _subCategoryAppService.GetAll(cancellation);

        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _serviceCategoryAppService.Update(ServiceCategory, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
