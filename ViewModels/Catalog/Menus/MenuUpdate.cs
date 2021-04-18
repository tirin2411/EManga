using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Menus
{
    public class MenuUpdate
    {
        public int Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Me-ta")]
        public string Meta { get; set; }

        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }
    }
}