using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CC_NUM { get; set; }
        public string Holder_name { get; set; }
        public DateTime Expire_date { get; set; }
        public int DiaChiId { get; set; }

        public DiaChi DiaChi { get; set; }
        public List<HoaDon> HoaDons { get; set; }
        public List<Payment> Payments { get; set; }
    }
}