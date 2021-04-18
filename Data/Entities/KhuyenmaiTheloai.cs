using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class KhuyenmaiTheloai
    {
        public int KhuyenmaiId { get; set; }
        public Khuyenmai Khuyenmai { get; set; }
        public int TheLoaiId { get; set; }
        public Theloai Theloai { get; set; }
    }
}
