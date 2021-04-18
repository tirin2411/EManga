using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class GioHang
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CouponCode { get; set; }
        public string OrderNote { get; set; }
        public List<GioHangDetail> GioHangDetails { get; set; }

    }
}