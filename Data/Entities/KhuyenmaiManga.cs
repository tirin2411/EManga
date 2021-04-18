using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class KhuyenmaiManga
    {
        public int KhuyenmaiId { get; set; }
        public Khuyenmai Khuyenmai { get; set; }
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
