using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class KhuyenmaiLichsuSudung
    {
        public int Id { get; set; }
        public int KhuyenmaiId { get; set; }
        public Khuyenmai Khuyenmai { get; set; }
        public int DonHangId { get; set; }
        public DonHang DonHang { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
