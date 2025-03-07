using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.DetailService
{
    public class DetailServiceModel(IServiceCategoryAppService _serviceCategoryAppService) : PageModel
    {

        [BindProperty]
        public ServiceCategorySummaryDto Service { get; set; }


        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
            Service = await _serviceCategoryAppService.GetById(id , cancellation);
        }
    }
}
