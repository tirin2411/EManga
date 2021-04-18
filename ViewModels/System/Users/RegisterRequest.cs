using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Display(Name = "Họ")]
        public string Ho { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}