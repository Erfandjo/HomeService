using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.CustomerEntity.Service;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Entities;

namespace App.Domain.AppServices.HomeService.Customer
{
    public class CustomerAppService(ICustomerService _customerService, IImageService _imageService) : ICustomerAppService
    {
        public async Task<string> GetBalance(int customerId, CancellationToken cancellation)
        {
            return await _customerService.GetBalance(customerId, cancellation);
        }

        public async Task<CustomerUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _customerService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Paid(int customerId, string price, CancellationToken cancellation)
        {
            return await _customerService.Paid(customerId, price, cancellation);
        }

        public async Task<Result> Update(CustomerUpdateDto customer, CancellationToken cancellation)
        {
            if (customer.ProfileImgFile is not null)
            {
                customer.ImagePath = await _imageService.UploadImage(customer.ProfileImgFile!, "Profiles", cancellation);
            }
            return await _customerService.Update(customer, cancellation);
        }
    }
}
