using App.Domain.Core.HomeService.CustomerEntity.Data;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.CustomerEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.HomeService.Customer
{
    public class CustomerRepository(AppDbContext _dbContext) : ICustomerRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.CustomerEntity.Entities.Customer customer, CancellationToken cancellation)
        {
            if (customer is null)
                return new Result(false, "Customer Is Null");

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer is null)
                return new Result(false, "Customer Not Found.");

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.CustomerEntity.Entities.Customer>>? GetAll(Domain.Core.HomeService.CustomerEntity.Entities.Customer customer, CancellationToken cancellation)
        {
            return await _dbContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<string> GetBalance(int customerId, CancellationToken cancellation)
        {
            var customer = await _dbContext.Customers.AsNoTracking().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == customerId);
            return customer.User.Balance;
        }

        public async Task<Domain.Core.HomeService.CustomerEntity.Entities.Customer>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Customers.AsNoTracking().Select(x => new CustomerUpdateDto()
            {
                Id = x.Id,
                Address = x.Address,
                CityId = x.User.CityId,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                PhoneNumber = x.User.PhoneNumber,
                UserName = x.User.UserName,
                Balance = x.User.Balance,
                ImagePath = x.User.ImagePath,
                Email = x.User.Email,

            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Paid(int customerId, string price, CancellationToken cancellation)
        {
            var cus = await _dbContext.Customers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == customerId);
            if (cus is null)
                return new Result(false, "مشتری پیدا نشد");

            cus.User.Balance = Convert.ToString(int.Parse(cus.User.Balance) - int.Parse(price));
        
            await _dbContext.SaveChangesAsync(cancellation);

            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<Result> Update(CustomerUpdateDto customer, CancellationToken cancellation)
        {
            var cus = await _dbContext.Customers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (cus is null)
                return new Result(false, "مشتری پیدا نشد");

            cus.Address = customer.Address;
            cus.User.UserName = customer.UserName;
            cus.User.Email = customer.Email;
            cus.User.Balance = customer.Balance;
            cus.User.FirstName = customer.FirstName;
            cus.User.LastName = customer.LastName;
            cus.User.PhoneNumber = customer.PhoneNumber;
            cus.User.CityId = customer.CityId;
            
            cus.User.ImagePath = customer.ImagePath;

            await _dbContext.SaveChangesAsync(cancellation);

            return new Result(true, "با موفقیت ویرایش شد");
        }
    }
}
