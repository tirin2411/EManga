using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace ViewModels.Catalog.Cart
{
    [Serializable]
    public class CartViewModel
    {
        public List<Manga> mangas { get; set; }
        public DonHang donhang { get; set; }
        public int Id { get; set; }
        public int MangaId { get; set; }
        public int soluong { get; set; }
        public string Ten { set; get; }
        public float Gia { set; get; }

        //public float Tongtien
        //{
        //    get
        //    {
        //        var tongtien = (float)Gia * soluong;
        //        return (float)Math.Ceiling(tongtien);
        //    }
        //}
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public IList<CartItem> Items { get; set; } = new List<CartItem>();
        public DateTime CreatedOn { get; set; }
        public string OrderNote { get; set; }
    }
}