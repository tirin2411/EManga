using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderItem
    {
        public int MangaId { get; set; }
        public string Hinh { get; set; }
        public string TenManga { get; set; }
        public float Gia { get; set; }
        public int SoLuong { get; set; }
        public float Khuyenmai { get; set; }

        public float ThanhTien
        {
            get
            {
                var tongtien = (float)Gia * SoLuong;
                return (float)Math.Ceiling(tongtien);
            }
        }
    }
}
