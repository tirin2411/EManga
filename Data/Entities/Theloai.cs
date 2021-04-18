using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Theloai
    {
        public int Id { get; set; }
        public string TenTL { get; set; }
        public string Meta { get; set; }
        public int Thutu { set; get; }
        public bool Anhien { set; get; }
        public List<MnTheloai> MnTheloais { get; set; }
        public List<KhuyenmaiTheloai> KhuyenmaiTheloais { get; set; }
    }
}