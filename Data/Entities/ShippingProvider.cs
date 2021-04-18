using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ShippingProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string ConfigureUrl { get; set; }
        public string AdditionalSettings { get; set; }
    }
}
