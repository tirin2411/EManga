using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class InforSell
    {
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}