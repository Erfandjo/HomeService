using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.ServiceCategoryEntity.Dto
{
    public class ServiceCategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public string BasePrice { get; set; }
        public IFormFile? ImgFile { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
    }
}
