using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CustomerEntity.Data
{
    public interface ICustomerRepository
    {
        public Task<Result> Add(Entities.Customer customer, CancellationToken cancellation);
        public Task<Result> Update(int id, Entities.Customer customer, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Entities.Customer>>? GetAll(Entities.Customer customer, CancellationToken cancellation);
        public Task<Entities.Customer>? GetById(int id, CancellationToken cancellation);
    }
}
