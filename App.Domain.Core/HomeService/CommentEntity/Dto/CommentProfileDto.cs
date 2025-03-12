using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.CommentEntity.Dto
{
    public class CommentProfileDto
    {
        public string Text { get; set; }
        public int Star { get; set; }
        public string? FullName { get; set; }
        public string ServiceName { get; set; }
    }
}
