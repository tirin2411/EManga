using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string TenMenu { get; set; }
        public string Meta { get; set; }
        public bool Anhien { get; set; }
        public int ThuTu { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}