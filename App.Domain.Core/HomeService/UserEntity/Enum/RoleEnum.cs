using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.UserEntity.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "ادمین")]
        Admin = 1,
        [Display(Name = "کارشناس")]
        Expert,
        [Display(Name = "مشتری")]
        Customer
    }
}
