using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.System.Users
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ")]
        public string Ho { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Giới tính")]
        public Gender GioiTinh { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}