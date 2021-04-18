using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Catalog.Order
{
    public class OrderUpdate
    {
        public int Id { get; set; }
        public string NguoiNhan { get; set; }
        public string SDT { get; set; }
        public string DiaChiNhan { get; set; }
        public OrderStatus Tinhtrang { get; set; }
    }
}