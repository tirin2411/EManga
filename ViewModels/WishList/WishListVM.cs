using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.WishList
{
    public class WishListVM
    {
        public int Id { get; set; }
        public List<WishListItemVM> Items { get; set; } = new List<WishListItemVM>();
    }
}
