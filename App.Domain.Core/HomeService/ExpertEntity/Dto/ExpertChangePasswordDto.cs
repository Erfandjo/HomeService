using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.ExpertEntity.Dto
{
    public class ExpertChangePasswordDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "رمزعبورفعلی نمیتواند خالی بماند")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "رمزعبور نمیتواند خالی بماند")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمزعبور نمیتواند خالی بماند")]
        public string Repassword { get; set; }
    }
}
