using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.CommentEntity.Entities;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;

namespace App.Domain.Core.HomeService.ExpertEntity.Dto
{
    public class ExpertProfileDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
        public float Score { get; set; }
        public string ImagePath { get; set; }
        public List<CommentProfileDto>? Comments { get; set; }
        public List<SkilsProfileDto>? Skils { get; set; }
    }
}
