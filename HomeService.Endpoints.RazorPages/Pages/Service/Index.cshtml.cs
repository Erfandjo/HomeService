using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data.Dapper;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.Service
{
    public class IndexModel(IServiceCategoryAppService _serviceCategoryAppService) : PageModel
    {


        [BindProperty]
        public List<ServiceCategorySummaryDto> ServiceCategory { get; set; }

        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
            ServiceCategory = await _serviceCategoryAppService.GetBySubCategoryId(id, cancellation);
        }
    }
}
