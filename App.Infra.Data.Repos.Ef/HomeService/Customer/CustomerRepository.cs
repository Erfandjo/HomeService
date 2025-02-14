using App.Domain.Core.HomeService.Admin.Entities;
using App.Domain.Core.HomeService.Base.Entities;
using App.Domain.Core.HomeService.Comment.Entities;
using App.Domain.Core.HomeService.Customer.Data;
using App.Domain.Core.HomeService.Result;
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
        public async Task<Result> Add(Domain.Core.HomeService.Customer.Entities.Customer customer, CancellationToken cancellation)
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

        public async Task<List<Domain.Core.HomeService.Customer.Entities.Customer>>? GetAll(Domain.Core.HomeService.Customer.Entities.Customer customer, CancellationToken cancellation)
        {
            return await _dbContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Customer.Entities.Customer>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Customer.Entities.Customer customer, CancellationToken cancellation)
        {
            var cus = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (cus is null)
                return new Result(false, "Customer Not Found.");


            


            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
