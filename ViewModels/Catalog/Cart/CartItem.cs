using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Cart
{
    public class CartItem
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