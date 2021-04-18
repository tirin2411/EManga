using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Khuyenmai
{
    public class KhuyenmaiCreateRequest
    {
        public string Name { set; get; }
        public string CouponCode { get; set; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public float? DiscountAmount { set; get; }
        public Status Status { set; get; }
        //public int MaximumDiscountedQuantity { get; set; }
    }
}
