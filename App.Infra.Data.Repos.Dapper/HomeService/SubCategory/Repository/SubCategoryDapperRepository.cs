using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.SubCategoryEntity.Data.Dapper;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Infra.Data.Repos.Dapper.HomeService.Category.Queries;
using App.Infra.Data.Repos.Dapper.HomeService.SubCategory.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Dapper.HomeService.SubCategory.Repository
{
    public class SubCategoryDapperRepository : ISubCategoryDapperRepository
    {

        private readonly string? _connectionString;

        public SubCategoryDapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration["SiteSettings:ConnectionStrings:SqlConnection"];
        }

        public async Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId, CancellationToken cancellation)
        {

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellation);

            var parameters = new { Id = categoryId };
            var subCategory = await connection.QueryAsync<SubCategorySummaryDto>(SubCategoryQueries.GetByCategoryId, parameters);

            return subCategory.ToList();
            
        }

        }

    }

