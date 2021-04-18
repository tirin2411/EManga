using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class DonHangDetail
    {
        public int DonHangId { get; set; }

        public int MangaId { get; set; }
        public float Gia { get; set; }
        public int Soluongdat { get; set; }
        public float Tongtien { get; set; }
        //bosung:
        public float Khuyenmai { get; set; }

        //public List<DonHangHtr> DonHangHtrs { get; set; }
        public DonHang DonHang { get; set; }

        public Manga Manga { get; set; }

        public List<ShipmentItem> ShipmentItems { get; set; }

    }
}