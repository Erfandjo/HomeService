using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.SuggestionEntity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SuggestionEntity.Dto
{
    public class SuggestionCreateDto
    {
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        [Column(TypeName = "int")]
        public string SuggestedPrice { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public DateOnly DeliveryDate { get; set; }
        [Required(ErrorMessage = "این قسمت نمیتواند خالی باشد")]
        public string? Description { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public DateTime SuggestionAt { get; set; }
        public StatusSuggestionEnum Status { get; set; }
    }
}
