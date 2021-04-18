using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Order
{
    public class OrderCreate
    {
        public Guid UserId { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string SDT { get; set; }
        public int MangaId { get; set; }
        public float Gia { get; set; }
        public int Soluongdat { get; set; }
        public float Tongtien { get; set; }
    }
}