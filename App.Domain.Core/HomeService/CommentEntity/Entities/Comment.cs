using App.Domain.Core.HomeService.CommentEntity.Enum;
using App.Domain.Core.HomeService.CustomerEntity.Entities;
using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;

namespace App.Domain.Core.HomeService.CommentEntity.Entities
{
    public class Comment
    {


        #region Properties
        public int Id { get; set; }
        public string Text { get; set; }
        public int Star { get; set; }
        public DateTime CommentAt { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int RequestId { get; set; }
        public StatusEnum StatusEnum { get; set; } = StatusEnum.IsPending;
        #endregion
        
        
        #region NavigationProperties
        public Expert Expert { get; set; }
        public Customer Customer { get; set; }
        public Request Request { get; set; }
        #endregion
    }
}
