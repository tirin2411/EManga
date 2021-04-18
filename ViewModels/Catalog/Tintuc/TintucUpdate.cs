using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Tintuc
{
    public class TintucUpdate
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Meta")]
        public string Meta { get; set; }

        //[Display(Name = "Hình")]
        //public string Hinh { get; set; }

        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        //[Display(Name = "Ngày cập nhật")]
        //public DateTime NgayCapNhat { get; set; }

        [Display(Name = "Hiện")]
        public bool AnHien { get; set; }
    }
}