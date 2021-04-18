using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.System.Users.Address
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Diachi { get; set; }
        public string TinhThanh { get; set; }
        public Guid UserId { get; set; }
    }
}