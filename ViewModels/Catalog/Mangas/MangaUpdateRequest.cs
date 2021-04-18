using Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Mangas
{
    public class MangaUpdateRequest
    {
        public int Id { get; set; }

        [Display(Name = "Tên truyện")]
        public string Ten { set; get; }

        [Display(Name = "Giá bán")]
        public float Gia { set; get; }

        [Display(Name = "Hiện")]
        public bool Anhien { set; get; }

        [Display(Name = "Tình trạng số lượng")]
        public TinhtrangSoluong SoLuong { get; set; }

        [Display(Name = "Mô tả")]
        public string Mota { get; set; }

        [Display(Name = "Tác giả")]
        public string Tacgia { get; set; }

        [Display(Name = "Năm xuất bản")]
        public string NamXB { get; set; }

        [Display(Name = "Số trang")]
        public int Sotrang { get; set; }

        //public IFormFile HinhNho { get; set; }
    }
}