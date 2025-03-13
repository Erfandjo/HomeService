using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.ExpertEntity.Data
{
    public interface IExpertRepository
    {
        public Task<Result> Add(Entities.Expert expert, CancellationToken cancellation);
        public Task<Result> Update(ExpertUpdateDto expert, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Entities.Expert>>? GetAll(Entities.Expert expert, CancellationToken cancellation);
        public Task<Entities.Expert>? GetById(int id, CancellationToken cancellation);
        public Task<Result> Price(int id, string price, CancellationToken cancellation);
        public Task<ExpertUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<ExpertProfileDto> GetByIdForProfile(int id, CancellationToken cancellation);
        public Task<List<int>>? GetExpertSkils(int expertId, CancellationToken cancellation);
    }
}
