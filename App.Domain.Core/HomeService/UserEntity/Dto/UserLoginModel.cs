using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.UserEntity.Dto
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "نام کاربری نمیتواند خالی بماند")]
        public string Username { get; set; }
        [Required(ErrorMessage = "رمزعبور نمیتواند خالی بماند")]
        public string Password { get; set; }
        [Required(ErrorMessage = "رمزعبور نمیتواند خالی بماند")]
        public bool RememberMe { get; set; }

    }
}
