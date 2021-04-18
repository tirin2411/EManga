using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class DiaChi
    {
        public int Id { get; set; }
        public string Tennguoinhan { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public string TinhThanh { get; set; }
        public string Ghichu { get; set; }
        public Guid UserId { get; set; }

        public AppUser AppUser { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}