using Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Mangas
{
    public class MangaCreateRequest
    {
        [Display(Name = "Tên truyện")]
        public string Ten { get; set; }
        public string Meta { get; set; }

        [Display(Name = "Giá bán")]
        public float Gia { get; set; }

        [Display(Name = "Giá gốc")]
        public float Giagoc { set; get; }
        [Display(Name = "Hiện")]
        public bool Anhien { set; get; }

        [Display(Name = "Ngôn ngữ của truyện")]
        public int NgonnguId { get; set; }

        [Display(Name = "Tình trạng hàng")]
        public TinhtrangSoluong SoLuong { get; set; }

        [Display(Name = "Tình trạng của truyện")]
        public TinhtrangMn TinhtrangMn { get; set; }

        [Display(Name = "Mô tả truyện")]
        public string Mota { get; set; }

        [Display(Name = "Tác giả")]
        public string Tacgia { get; set; }

        [Display(Name = "Năm xuất bản")]
        public string NamXB { get; set; }

        [Display(Name = "Số trang")]
        public int Sotrang { get; set; }

        [Display(Name = "Thể loại")]
        public int TheloaiId { get; set; }

        [Display(Name = "Hình")]
        public IFormFile HinhNho { get; set; }

        [Display(Name = "Người bán")]
        public Guid UserId { get; set; }
    }
}