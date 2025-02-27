using App.Domain.Core.HomeService.CommentEntity.Enum;

namespace App.Domain.Core.HomeService.CommentEntity.Dto
{
    public class CommentSummaryDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CommentAt { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int RequestId { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}
