using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class DonHangHistory
    {
        public int id { get; set; }

        //public int DonHangDetailId { get; set; }
        public float Tongtien { get; set; }

        public Status Trangthai { get; set; }
        public string Ghichu { get; set; }
        public DateTime Ngaplap { get; set; }

        //public DonHangDetail DonHangDetail { get; set; }
    }
}