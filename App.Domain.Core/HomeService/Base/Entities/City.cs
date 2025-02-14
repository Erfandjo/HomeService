using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Base.Entities
{
    public class City
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        #endregion


        #region NavigationProperties
        public List<User.Entities.User> Users { get; set; }
        #endregion
    }
}
