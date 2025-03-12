using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.ExpertEntity.Dto
{
    public class ExpertUpdateDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public string Balance { get; set; }
        public int? CityId { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? ImagePath { get; set; }
        public string? Biography { get; set; }
        [DisplayName("مهارت ها")]
        public List<int>? Skils { get; set; }
    }
}
