using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.Service
{
    public class IndexModel(IServiceCategoryDapperRepository _serviceCategoryDapperRepository) : PageModel
    {


        [BindProperty]
        public List<ServiceCategorySummaryDto> ServiceCategory { get; set; }

        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
            ServiceCategory = await _serviceCategoryDapperRepository.GetBySubCategoryId(id, cancellation);
        }
    }
}
