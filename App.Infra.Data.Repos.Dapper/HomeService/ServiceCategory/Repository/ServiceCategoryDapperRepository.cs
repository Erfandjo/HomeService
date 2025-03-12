using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Infra.Data.Repos.Dapper.HomeService.ServiceCategory.Queries;
using App.Infra.Data.Repos.Dapper.HomeService.SubCategory.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Dapper.HomeService.ServiceCategory.Repository
{
    public class ServiceCategoryDapperRepository : IServiceCategoryDapperRepository
    {

        private readonly string? _connectionString;

        public ServiceCategoryDapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration["SiteSettings:ConnectionStrings:SqlConnection"];
        }



        public Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellation);

            var parameters = new { Id = subCategoryId };
            var subCategory = await connection.QueryAsync<ServiceCategorySummaryDto>(ServiceCategoryQueries.GetBySubCategoryId, parameters);

            return subCategory.ToList();
        }
    }
}
