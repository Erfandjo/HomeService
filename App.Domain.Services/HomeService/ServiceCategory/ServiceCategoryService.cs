﻿using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data.Dapper;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data.EntityFramework;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Service;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;

namespace App.Domain.Services.HomeService.ServiceCategory
{
    public class ServiceCategoryService(IServiceCategoryRepository _serviceCategoryRepository , IServiceCategoryDapperRepository _serviceCategoryDapperRepository) : IServiceCategoryService
    {
        public async Task<Result> Add(ServiceCategoryCreateDto service, CancellationToken cancellation)
        {
            return await _serviceCategoryRepository.Add(service , cancellation);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _serviceCategoryRepository.Delete(id, cancellation);
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _serviceCategoryRepository.GetAll(cancellation);
        }

        public async Task<ServiceCategorySummaryDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _serviceCategoryRepository.GetById(id, cancellation);
        }

        public async Task<ServiceCategoryUpdateDto> GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _serviceCategoryRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation)
        {
            return await _serviceCategoryDapperRepository.GetBySubCategoryId(subCategoryId, cancellation);
        }

        public async Task<List<SkilsProfileDto>>? GetSkils(CancellationToken cancellation)
        {
            return await _serviceCategoryRepository.GetSkils(cancellation);
        }

        public async Task<Result> Update(ServiceCategoryUpdateDto service, CancellationToken cancellation)
        {
            return await (_serviceCategoryRepository.Update(service , cancellation));
        }
    }
}
