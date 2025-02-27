using App.Domain.Core.HomeService.DashboardEntity.AppService;
using App.Domain.Core.HomeService.DashboardEntity.Dtos;
using App.Domain.Core.HomeService.UserEntity.Service;

namespace App.Domain.AppServices.HomeService.Dashboard
{

    public class DashboardAppService(IUserService _userService) : IDashboardAppService
    {
        
        public async Task<StatisticsDataDto> GetStatisticsData(CancellationToken cancellation)
        {
            var model = new StatisticsDataDto();

            model.UserCount = await _userService.GetCount(cancellation);
            model.AdvertisementCount = 10;
            model.CategoryCount = 15;
            model.BrandCount = 3;

            return model;
        }
    }
}

