using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class HoaDon
    {
        public int Id { get; set; }
        public int CreditCardId { get; set; }
        public int DiaChiId { get; set; }
        public DateTime Creation_date { get; set; }
        public string State_desc { get; set; }
        public string Notes { get; set; }
        public DateTime Timestamp { get; set; }

        public List<HoaDonHistory> HoaDonHistories { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}