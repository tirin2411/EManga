using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class MnTheloai
    {
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public int TheLoaiId { get; set; }
        public Theloai Theloai { get; set; }
    }
}
