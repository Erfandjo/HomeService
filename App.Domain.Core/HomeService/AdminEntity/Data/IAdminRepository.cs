using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.AdminEntity.Data
{
    public interface IAdminRepository
    {
        public Task<Result> Add(Entities.Admin admin, CancellationToken cancellation);
        public Task<Result> Update(int id, Entities.Admin admin, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Entities.Admin>>? GetAll(Entities.Admin admin, CancellationToken cancellation);
        public Task<Entities.Admin>? GetById(int id, CancellationToken cancellation);
    }
}
