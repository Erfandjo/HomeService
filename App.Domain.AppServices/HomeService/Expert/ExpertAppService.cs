using App.Domain.Core.HomeService.ExpertEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.AppServices.HomeService.Expert
{
    public class ExpertAppService(IExpertService _expertService) : IExpertAppService
    {
        public async Task<ExpertProfileDto> GetByIdForProfile(int id, CancellationToken cancellation)
        {
            return await _expertService.GetByIdForProfile(id, cancellation);
        }

        public async Task<ExpertUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _expertService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Update(ExpertUpdateDto expert, CancellationToken cancellation)
        {
            return await _expertService.Update(expert, cancellation);
        }
    }
}
