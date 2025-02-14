namespace App.Domain.Core.HomeService.Service.Data
{
    public interface IServiceRepository
    {
        public Task<Result.Result> Add(Service.Entities.Service service , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Service.Entities.Service service, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Service.Entities.Service>>? GetAll(Service.Entities.Service service, CancellationToken cancellation);
        public Task<Service.Entities.Service>? GetById(int id , CancellationToken cancellation);
    }
}
