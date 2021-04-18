using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Menus
{
    public class MenuItemVM
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        [Display(Name = "Đường dẫn")]
        public string CustomLink { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        public string Meta { get; set; }
        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }
    }
}
