using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class WishListItem
    {
        public int Id { get; set; }
        public int WishListId { get; set; }
        public WishList WishList { get; set; }
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public float Gia { get; set; }
        public int Soluongdat { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
