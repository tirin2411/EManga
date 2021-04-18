using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class MangaImage
    {
        public int Id { get; set; }
        public int MangaId { get; set; }
        public string LinkAnh { get; set; }
        public string ChuThich { get; set; }
        public bool Anhmacdinh { get; set; }
        public int ThuTu { get; set; }
        public long FileSize { get; set; }

        public Manga Manga { get; set; }

    }
}
