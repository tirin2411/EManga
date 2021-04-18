using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ShippingTableRate
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int DistricId { get; set; }
        public int WardId { get; set; }
        public string Note { get; set; }
        public Decimal ShippingPrice { get; set; }


    }
}
