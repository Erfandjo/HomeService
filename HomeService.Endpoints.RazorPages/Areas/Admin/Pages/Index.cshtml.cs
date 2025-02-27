using App.Domain.Core.HomeService.DashboardEntity.AppService;
using App.Domain.Core.HomeService.DashboardEntity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages
{
    // [Authorize(Roles = "Admin")]
    public class IndexModel(IDashboardAppService _dashboardAppService) : PageModel
    {

        [BindProperty]
        public StatisticsDataDto DashboardData { get; set; }

        public async Task OnGet(CancellationToken cancellation)
        {
           // StatisticsDataDto model = new StatisticsDataDto() { AdvertisementCount = 10, BrandCount = 5, CategoryCount = 16, UserCount = 10 };
            DashboardData = await _dashboardAppService.GetStatisticsData(cancellation);
            var data = User;
        }
    }
}
