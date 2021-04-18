using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ShipmentItem
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public int OrderItemId { get; set; }
        public int MangaId { get; set; }
        public int Quantity { get; set; }
        public DonHangDetail DonHangDetail { get; set; }
        public Manga Manga { get; set; }
    }
}
