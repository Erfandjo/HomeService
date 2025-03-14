using App.Domain.Core.HomeService.CommentEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using App.Domain.Core.HomeService.SuggestionEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.ExpertEntity.Entities
{
    public class Expert
    {
        #region Properties
        public int Id { get; set; }
        public float Score { get; set; } = 0;
        public string? Biography { get; set; }

        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public UserEntity.Entities.User User { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<ServiceCategory>? Skils { get; set; }
        public List<Suggestion>? Suggestions { get; set; }
        public List<Request>? AcceptedRequests { get; set; }
        #endregion
    }
}
