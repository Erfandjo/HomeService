using App.Domain.Core.HomeService.ImageEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestCreateDto
    {
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public DateOnly DateOfCompletion { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public TimeOnly TimeOfCompletion { get; set; }
        public string? Description { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        [Column(TypeName = "int")]
        public int Price { get; set; }
        public List<IFormFile>? Images { get; set; }
        public DateTime RequestAt { get; set; }
        public StatusRequestEnum Status { get; set; }
   
    }
}
