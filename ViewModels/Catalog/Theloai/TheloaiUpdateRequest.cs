using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Theloai
{
    public class TheloaiUpdateRequest
    {
        public int Id { get; set; }
        public string TenTL { get; set; }
        public string Meta { get; set; }

        public int Thutu { set; get; }
        public bool Anhien { set; get; }
    }
}