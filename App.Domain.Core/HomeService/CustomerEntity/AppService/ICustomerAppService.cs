using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CustomerEntity.AppService
{
    public interface ICustomerAppService
    {

        public Task<Result> Update(CustomerUpdateDto customer, CancellationToken cancellation);
        public Task<CustomerUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<Result> Paid(int customerId, string price, CancellationToken cancellation);
        public Task<string> GetBalance(int customerId, CancellationToken cancellation);
    }
}
