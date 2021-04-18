using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Manga
    {
        public int Id { set; get; }
        public string Ten { set; get; }
        public float Gia { set; get; }
        public float Giagoc { set; get; }
        public string HinhAnh { get; set; }
        public string Meta { get; set; }

        public bool Anhien { set; get; }
        public int NgonnguId { set; get; }

        public NgonnguMn NgonnguMn { get; set; }
        public List<MnTheloai> MnTheloais { get; set; }
        public List<DonHangDetail> DonHangDetails { get; set; }
        public List<GioHangDetail> GioHangDetails { get; set; }
        public List<MangaDetail> MangaDetails { get; set; }
        public List<MangaImage> MangaImages { get; set; }
        public List<MComment> MComments { get; set; }
        public List<InforSell> InforSells { get; set; }
        public List<KhuyenmaiManga> KhuyenmaiMangas { get; set; }
        public List<ShipmentItem> ShipmentItems { get; set; }
        public List<WishListItem> WishListItems { get; set; }

    }
}