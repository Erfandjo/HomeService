using App.Domain.Core.HomeService.DashboardEntity.Dtos;

namespace App.Domain.Core.HomeService.DashboardEntity.AppService
{
    public interface IDashboardAppService
    {
        public Task<StatisticsDataDto> GetStatisticsData(CancellationToken cancellation);
    }
}
