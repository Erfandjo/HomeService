﻿using App.Domain.Core.HomeService.UserEntity.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.UserEntity.Dto
{
    public class UserUpdateDto
    {

        #region Properties

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "نام کاربری نمیتواند خالی بماند")]
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Balance { get; set; }
        public int? CityId { get; set; }
        [Required(ErrorMessage = "نقش نمیتواند خالی بماند")]
        public RoleEnum Role { get; set; }
        public IFormFile? ProfileImgFile { get; set; }

        public string? ImagePath { get; set; }
        #endregion

    }
}
