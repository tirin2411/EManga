using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Khuyenmai
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public float? DiscountAmount { set; get; }
        public Status Status { set; get; }
        public string Name { set; get; }
        public string CouponCode { get; set; }
        public int MaximumDiscountedQuantity { get; set; }
       
        public List<KhuyenmaiManga> KhuyenmaiMangas { get; set; }
        public List<KhuyenmaiTheloai> KhuyenmaiTheloais { get; set; }
        public List<KhuyenmaiLichsuSudung> KhuyenmaiLichsuSudungs { get; set; }


    }
}
