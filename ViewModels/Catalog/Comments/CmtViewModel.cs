using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Comments
{
    public class CmtViewModel
    {
        public int Id { get; set; }
        public int MangaId { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayComment { get; set; }
        public Guid UserId { get; set; }
    }
}