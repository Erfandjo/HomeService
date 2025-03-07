using App.Domain.Core.HomeService.CommentEntity.Enum;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.CommentEntity.Dto
{
    public class CommentCreateDto
    {
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public string Text { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        [Range(1, 5 , ErrorMessage ="باید بین یک تا پنج باشد")]
        public int Star { get; set; }
        public DateTime CommentAt { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int RequestId { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}
