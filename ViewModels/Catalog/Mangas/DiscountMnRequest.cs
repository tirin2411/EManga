using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Common;

namespace ViewModels.Catalog.Mangas
{
    public class DiscountMnRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Discounts { get; set; } = new List<SelectItem>();
    }
}
