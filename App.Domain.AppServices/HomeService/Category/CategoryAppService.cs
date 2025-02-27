using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CategoryEntity.Service;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace App.Domain.AppServices.HomeService.Category
{
    public class CategoryAppService(ICategoryService _categoryService , IImageService _imageService) : ICategoryAppService
    {
        public async Task<Result> Add(CategoryCreateDto category, CancellationToken cancellation)
        {
            if (category.ImgFile is not null)
            {

                category.ImagePath = await _imageService.UploadImage(category.ImgFile, "Category", cancellation);

            }

            var result = await _categoryService.Add(category, cancellation);

            

            return result;
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _categoryService.Delete(id, cancellation);
        }

        public async Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _categoryService.GetAll(cancellation);
        }

        public async Task<CategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _categoryService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Update(CategoryUpdateDto Category, CancellationToken cancellation)
        {
            if (Category.ImgFile is not null)
            {
                Category.ImagePath = await _imageService.UploadImage(Category.ImgFile!, "Category", cancellation);
            }
            return await _categoryService.Update(Category, cancellation);
        }
    }
}
