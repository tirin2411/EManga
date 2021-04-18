using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CreditCardId { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}