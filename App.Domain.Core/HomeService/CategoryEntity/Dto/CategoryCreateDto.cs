using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.CategoryEntity.Dto
{
    public class CategoryCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImgFile { get; set; }
    }
}
