using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class NgonnguMn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Anhien { get; set; }
        public string Meta { get; set; }

        public List<Manga> Mangas { get; set; }
    }
}