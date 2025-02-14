using App.Domain.Core.HomeService.Request.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Customer.Entities
{
    public class Customer
    {
        #region Properties
        public int Id { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public User.Entities.User User { get; set; }
        public List<Request.Entities.Request>? Requests { get; set; }
        #endregion

    }
}
