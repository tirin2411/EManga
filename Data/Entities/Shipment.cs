using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DonHang DonHang { get; set; }
        /*id nguoi ban*/
        public int VendorId { get; set; }

        public int CreateById { get; set; }
        public DateTime CreateOn { get; set; }
        public List<ShipmentItem> ShipmentItems { get; set; }

    }
}
