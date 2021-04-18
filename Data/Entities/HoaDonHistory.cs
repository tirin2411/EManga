using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class HoaDonHistory
    {
        public int HoaDonId { get; set; }
        public string State_desc { get; set; }
        public string Notes { get; set; }
        public DateTime Timestamp { get; set; }

        public HoaDon HoaDon { get; set; }
    }
}