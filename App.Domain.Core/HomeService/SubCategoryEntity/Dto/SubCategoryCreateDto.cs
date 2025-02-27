using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.SubCategoryEntity.Dto
{
    public class SubCategoryCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImgFile { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
