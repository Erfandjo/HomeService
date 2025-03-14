using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CityEntity.Data.Dapper;
using App.Infra.Data.Repos.Dapper.HomeService.Category.Queries;
using App.Infra.Data.Repos.Dapper.HomeService.City.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace App.Infra.Data.Repos.Dapper.HomeService.City.Repository
{
    public class CityDapperRepository : ICityDapperRepository
    {

        private readonly string? _connectionString;

        public CityDapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration["SiteSettings:ConnectionStrings:SqlConnection"];
        }


        public async Task<List<App.Domain.Core.HomeService.CityEntity.Entities.City>>? GetAll(CancellationToken cancellation)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellation);

            var result = await connection.QueryAsync<App.Domain.Core.HomeService.CityEntity.Entities.City>(CityQueries.GetAll, cancellation);
            return result.ToList();
        }
    }
}
