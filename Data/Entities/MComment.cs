using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class MComment
    {
        public int Id { get; set; }
        public int MangaId { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayComment { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }

        public Manga Manga { get; set; }

    }
}
