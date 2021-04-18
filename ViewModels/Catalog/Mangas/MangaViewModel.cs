using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Catalog.Mangas
{
    public class MangaViewModel
    {
        public int mangaId { set; get; }

        [Display(Name = "Tên")]
        public string Ten { set; get; }

        [Display(Name = "Giá")]
        public float Gia { set; get; }

        [Display(Name = "Giá gốc")]
        public float Giagoc { set; get; }

        [Display(Name = "Hiện")]
        public bool Anhien { set; get; }

        [Display(Name = "Tình trạng số lượng")]
        public TinhtrangSoluong SoLuong { get; set; }

        [Display(Name = "Tình trạng của truyện")]
        public TinhtrangMn TinhtrangMn { get; set; }

        [Display(Name = "Mô tả")]
        public string Mota { get; set; }

        [Display(Name = "Tác giả")]
        public string Tacgia { get; set; }

        [Display(Name = "Năm xuất bản")]
        public string NamXB { get; set; }

        [Display(Name = "Số trang")]
        public int Sotrang { get; set; }

        [Display(Name = "Thể loại")]
        public int TheloaiId { get; set; }

        [Display(Name = "Ảnh")]
        public string LinkAnh { get; set; }

        [Display(Name = "Người bán")]
        public Guid UserId { get; set; }

        [Display(Name ="Meta")]
        public string meta { get; set; }
        public long FileSize { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public List<string> Discounts { get; set; } = new List<string>();
    }
}