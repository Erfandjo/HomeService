using App.Domain.Core.HomeService.RequestEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.ImageEntity.Entities
{
    public class Image
    {
        #region Properties
        public int Id { get; set; }
        public string Path { get; set; }
        public int RequestId { get; set; }
        #endregion

        public Request Request { get; set; }
    }
}
