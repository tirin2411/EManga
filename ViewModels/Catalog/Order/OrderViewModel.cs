using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = "Người nhận")]
        public string NguoiNhan { get; set; }

        [Display(Name = "Địa chỉ nhận")]
        public string DiaChiNhan { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tình trạng đơn hàng")]
        public OrderStatus Tinhtrang { get; set; }

        public int MangaId { get; set; }

        [Display(Name = "Tên truyện")]
        public string TenMn { get; set; }

        [Display(Name = "Ảnh")]
        public string LinkAnh { get; set; }

        [Display(Name = "Giá")]
        public float Gia { get; set; }

        [Display(Name = "Số lượng")]
        public int Soluongdat { get; set; }

        [Display(Name = "Tình trạng thanh toán")]
        public TinhtrangThanhtoan TinhtrangThanhtoan { get; set; }

        [Display(Name = "Tổng tiền")]
        //public float Tongtien { get; set; }
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