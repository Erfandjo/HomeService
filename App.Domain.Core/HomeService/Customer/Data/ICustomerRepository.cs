namespace App.Domain.Core.HomeService.Customer.Data
{
    public interface ICustomerRepository
    {
        public Task<Result.Result> Add(Customer.Entities.Customer customer , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Customer.Entities.Customer customer, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Customer.Entities.Customer>>? GetAll(Customer.Entities.Customer customer, CancellationToken cancellation);
        public Task<Customer.Entities.Customer>? GetById(int id, CancellationToken cancellation);
    }
}
