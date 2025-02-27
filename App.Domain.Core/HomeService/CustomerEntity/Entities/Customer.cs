using App.Domain.Core.HomeService.CommentEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.CustomerEntity.Entities
{
    public class Customer
    {
        #region Properties
        public int Id { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public UserEntity.Entities.User User { get; set; }
        public List<Request>? Requests { get; set; }
        public List<Comment> Comments { get; set; }
        #endregion

    }
}
