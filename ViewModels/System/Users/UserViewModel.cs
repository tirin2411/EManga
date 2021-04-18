using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Display(Name = "Họ")]
        public string Ho { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Giới tính")]
        public Gender GioiTinh { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        public IList<string> Roles { get; set; }
    }
}