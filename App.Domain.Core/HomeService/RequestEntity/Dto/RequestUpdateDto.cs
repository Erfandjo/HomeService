using App.Domain.Core.HomeService.RequestEntity.Enum;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestUpdateDto
    {
        public int Id { get; set; }
        public StatusRequestEnum StatusRequest { get; set; }

    }
}
