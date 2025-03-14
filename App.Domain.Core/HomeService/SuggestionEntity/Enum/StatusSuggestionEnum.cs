using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.SuggestionEntity.Enum
{
    public enum StatusSuggestionEnum
    {
        [Display(Name = "انتخاب نشدید")]
        NotSelection = 1,
        [Display(Name = "انتخاب شدید")]
        Selected,
        [Display(Name = "تمام شده")]
        finished,
        [Display(Name = "پرداخت شده")]
        Paid,
    }
}
