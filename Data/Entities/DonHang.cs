using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class DonHang
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime Ngaynhan { get; set; }
        public Guid UserId { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public OrderStatus Tinhtrang { get; set; }
        public int DiaChiId { get; set; }
        public float TongTien { get; set; }
        public TinhtrangThanhtoan TinhtrangThanhtoan { get; set; }

        public DiaChi DiaChi { get; set; }
        public List<DonHangDetail> DonHangDetails { get; set; }
        public List<Shipment> Shipments { get; set; }

        public AppUser AppUser { get; set; }
        public List<KhuyenmaiLichsuSudung> KhuyenmaiLichsuSudungs { get; set; }

    }
}