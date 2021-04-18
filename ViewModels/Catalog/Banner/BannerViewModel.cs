using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Banner
{
    public class BannerViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }

        public string Meta { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Tieude { get; set; }

        [Display(Name = "Nội dung")]
        public string Noidung { get; set; }

        [Display(Name = "Hiện")]
        public bool Anhien { get; set; }
    }
}