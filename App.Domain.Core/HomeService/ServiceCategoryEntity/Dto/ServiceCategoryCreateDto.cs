using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.ServiceCategoryEntity.Dto
{
    public class ServiceCategoryCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImgFile { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        public string BasePrice { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
