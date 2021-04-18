using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.MangaImages
{
    public class MangaImageViewModel
    {
        public int Id { get; set; }

        public int MangaId { get; set; }

        public string LinkAnh { get; set; }

        public string ChuThich { get; set; }

        public bool Anhmacdinh { get; set; }

        public int ThuTu { get; set; }

        public long FileSize { get; set; }
    }
}
