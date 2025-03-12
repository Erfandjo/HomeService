using App.Domain.Core.HomeService.CategoryEntity.Data.Dapper;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Infra.Data.Repos.Dapper.HomeService.Category.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace App.Infra.Data.Repos.Dapper.HomeService.Category.Repository
{
    public class CategoryDapperRepository : ICategoryDapperRepository
    {

        private readonly string? _connectionString;

        public CategoryDapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration["SiteSettings:ConnectionStrings:SqlConnection"];
        }


        public async Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellation);

            var result = await connection.QueryAsync<CategorySummaryDto>(CategoryQueries.GetAll, cancellation);
            return result.ToList();
        }
    }
}
