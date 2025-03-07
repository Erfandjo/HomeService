using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.CustomerEntity.Dto
{
    public class CustomerChangePasswordDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "این فیلد نمیتواند خالی بماند")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage ="این فیلد نمیتواند خالی بماند")]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی بماند")]
        public string Repassword { get; set; }

    }
}
