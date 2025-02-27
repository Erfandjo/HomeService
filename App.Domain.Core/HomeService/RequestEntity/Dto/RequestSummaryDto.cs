using App.Domain.Core.HomeService.RequestEntity.Enum;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestSummaryDto
    {
        public int Id { get; set; }
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? Description { get; set; }
        public DateTime RequestAt { get; set; }
        public int CustomerId { get; set; }
        public StatusRequestEnum Status { get; set; }
        public string ServiceName { get; set; }
        public int Price { get; set; }
    }
}
