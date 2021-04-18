using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.WishList
{
    public class WishListItemVM
    {
        public int Id { get; set; }
        public int WishListId { get; set; }
        public int MangaId { get; set; }
        public string MangaName { get; set; }
        public string MangaImg { get; set; }
        public float MangaPrice { get; set; }
        public int Quantity { get; set; }
    }
}
