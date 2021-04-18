using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public string Hinh { get; set; }
        public long FileSize { get; set; }

        public int ThuTu { get; set; }
        public string Meta { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public bool Anhien { get; set; }
    }
}