using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Tintuc
{
    public class TintucCreateRequest
    {
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Meta")]
        public string Meta { get; set; }

        [Display(Name = "Hình")]
        public IFormFile Hinh { get; set; }

        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Hiện")]
        public bool Anhien { get; set; }
    }
}