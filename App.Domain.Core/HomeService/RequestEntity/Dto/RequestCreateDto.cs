using App.Domain.Core.HomeService.ImageEntity.Entities;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestCreateDto
    {
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? Description { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int Price { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
