using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.SuggestionEntity.Enum
{
    public enum StatusSuggestionEnum
    {
        [Display(Name = "در انتظار انتخاب مشتری")]
        WaitingCustomerSelection = 1,
        [Display(Name = "انتخاب شده")]
        Selected,
        [Display(Name = "تمام شده")]
        finished,
        [Display(Name = "پرداخت شده")]
        Paid,
    }
}
