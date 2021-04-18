using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Order
{
    public class OrderVM
    {
        public int Id { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; }
        public Guid UserId { get; set; }

        [Display(Name = "Người nhận")]
        public string NguoiNhan { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Wards { get; set; }

        [Display(Name = "Địa chỉ nhận")]
        public string DiaChiNhan { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tình trạng đơn hàng")]
        public OrderStatus Tinhtrang { get; set; }
        public TinhtrangThanhtoan TinhtrangThanhtoan { get; set; }
        public float Tongtien { get; set; }

    }
}