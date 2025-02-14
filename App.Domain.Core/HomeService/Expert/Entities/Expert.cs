using App.Domain.Core.HomeService.Suggestion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Expert.Entities
{
    public class Expert
    {
        #region Properties
        public int Id { get; set; }
        public int Score { get; set; } = 0;
        public string? Biography { get; set; }
        
        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public User.Entities.User User { get; set; }
        public List<Comment.Entities.Comment>? Comments { get; set; }
        public List<Service.Entities.Service>? Skils { get; set; }
        public List<Suggestion.Entities.Suggestion>? Suggestions { get; set; }
        #endregion
    }
}
