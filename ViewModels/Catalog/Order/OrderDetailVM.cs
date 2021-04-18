using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Order
{
    public class OrderDetailVM
    {
        public int DonhangId { get; set; }

        public int MangaId { get; set; }

        [Display(Name = "Tên truyện")]
        public string TenMn { get; set; }

        [Display(Name = "Ảnh")]
        public string LinkAnh { get; set; }

        [Display(Name = "Giá")]
        public float Gia { get; set; }

        [Display(Name = "Số lượng")]
        public int Soluongdat { get; set; }

        [Display(Name = "Tổng tiền")]
        public float Tongtien
        {
            get
            {
                var tongtien = (float)Gia * Soluongdat;
                return (float)Math.Ceiling(tongtien);
            }
        }
    }
}