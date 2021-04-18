using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Theloai
{
    public class TheloaiCreateRequest
    {
        public string TenTL { get; set; }
        public string Meta { get; set; }

        public int Thutu { set; get; }
        public bool Anhien { set; get; }
    }
}