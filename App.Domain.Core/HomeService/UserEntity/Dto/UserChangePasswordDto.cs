using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.UserEntity.Dto
{
    public class UserChangePasswordDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "رمزعبور نمیتواند خالی بماند")]
        public string Password { get; set; }
        [Required(ErrorMessage = "رمزعبور نمیتواند خالی بماند")]
        public string Repassword { get; set; }
    }
}
