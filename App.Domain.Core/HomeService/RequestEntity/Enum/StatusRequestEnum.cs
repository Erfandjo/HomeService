using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.RequestEntity.Enum
{
    public enum StatusRequestEnum
    {
        [Display(Name = "در انتظار ارسال پیشنهاد")]
        WaitingSuggestion = 1,
        [Display(Name = "در انتظار انتخاب کارشناس")]
        WaitingExpertSelection,
        [Display(Name = "کارشناس انتخاب شده")]
        ExpertSelection,
        [Display(Name = "شروع شده")]
        Started,
        [Display(Name = "در انتظار پرداخت")]
        WaitingPayment,
        [Display(Name = "پرداخت شده")]
        Paid
    
    }
}
