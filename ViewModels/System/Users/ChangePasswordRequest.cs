using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.System.Users
{
    public class ChangePasswordRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string newPassword { get; set; }
        //public string ConfirmPassword { get; set; }
        //public bool validatePassword { get; set; }
    }
}