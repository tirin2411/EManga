using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        //public int ParentId { get; set; }
        //public MenuItem Menuitem { get; set; }
        public string CustomLink { get; set; }
        public string Name { get; set; }
        public string Meta { get; set; }
        public int ThuTu { get; set; }
        //public List<MenuItem> MenuItems { get; set; }


    }
}
