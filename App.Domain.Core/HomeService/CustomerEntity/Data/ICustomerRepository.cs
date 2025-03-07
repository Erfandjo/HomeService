using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CustomerEntity.Data
{
    public interface ICustomerRepository
    {
        public Task<Result> Add(Entities.Customer customer, CancellationToken cancellation);
        public Task<Result> Update(CustomerUpdateDto customer, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Entities.Customer>>? GetAll(Entities.Customer customer, CancellationToken cancellation);
        public Task<Entities.Customer>? GetById(int id, CancellationToken cancellation);
        public Task<CustomerUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<Result> Paid(int customerId , string price , CancellationToken cancellation);
        public Task<string> GetBalance(int customerId, CancellationToken cancellation);
    }
}
