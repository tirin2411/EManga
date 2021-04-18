using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.System.InfoSell
{
    public class SellViewModel
    {
        public int MangaId { get; set; }
        public string Ten { set; get; }
        public float Gia { set; get; }
        public float Giagoc { set; get; }
        public TinhtrangSoluong SoLuong { get; set; }
        public TinhtrangMn TinhtrangMn { get; set; }
        public string Mota { get; set; }
        public string Tacgia { get; set; }
        public string NamXB { get; set; }
        public int Sotrang { get; set; }
        public string LinkAnh { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
    }
}