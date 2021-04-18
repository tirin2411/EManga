using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace ViewModels.Catalog.Cart
{
    [Serializable]
    public class ItemMn
    {
        public Manga Manga { get; set; }
        public int Soluong { get; set; }
    }
}