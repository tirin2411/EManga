using Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime Dob { get; set; }
        public Gender GioiTinh { get; set; }

        public List<GioHang> GioHangs { get; set; }
        public List<DonHang> DonHangs { get; set; }
        public List<InforSell> InforSells { get; set; }
        public List<MComment> MComments { get; set; }
        public List<DiaChi> DiaChis { get; set; }

        public List<Giaodich> Giaodiches { get; set; }
        public List<WishList> WishLists { get; set; }
    }
}