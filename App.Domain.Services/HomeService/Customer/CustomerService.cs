using App.Domain.Core.HomeService.CustomerEntity.Data;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.CustomerEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Services.HomeService.Customer
{
    public class CustomerService(ICustomerRepository _customerRepository) : ICustomerService
    {
        public async Task<string> GetBalance(int customerId, CancellationToken cancellation)
        {
            return await _customerRepository.GetBalance(customerId, cancellation);
        }

        public async Task<CustomerUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _customerRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Paid(int customerId, string price, CancellationToken cancellation)
        {
            return await _customerRepository.Paid(customerId, price, cancellation);
        }

        public async Task<Result> Update(CustomerUpdateDto customer, CancellationToken cancellation)
        {
            return await _customerRepository.Update(customer, cancellation);
        }
    }
}
