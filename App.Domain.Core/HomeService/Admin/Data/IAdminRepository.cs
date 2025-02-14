namespace App.Domain.Core.HomeService.Admin.Data
{
    public interface IAdminRepository
    {
        public Task<Result.Result> Add(Admin.Entities.Admin admin, CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Admin.Entities.Admin admin, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Admin.Entities.Admin>>? GetAll(Admin.Entities.Admin admin, CancellationToken cancellation);
        public Task<Admin.Entities.Admin>? GetById(int id , CancellationToken cancellation);
    }
}
