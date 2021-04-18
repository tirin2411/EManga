using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Shipment
{
    public class ShippingPriceUpdate
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}
