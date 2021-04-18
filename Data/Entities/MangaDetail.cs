using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class MangaDetail
    {
        public int MangaId { get; set; }
        public TinhtrangSoluong SoLuong { get; set; }
        public TinhtrangMn TinhtrangMn { get; set; }
        public string Mota { get; set; }
        public string Tacgia { get; set; }
        public string NamXB { get; set; }
        public int Sotrang { get; set; }

        public Manga Manga { get; set; }


    }
}
