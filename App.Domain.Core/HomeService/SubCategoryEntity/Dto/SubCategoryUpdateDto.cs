using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SubCategoryEntity.Dto
{
    public class SubCategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImgFile { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
