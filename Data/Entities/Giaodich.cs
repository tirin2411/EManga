using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Giaodich
    {
        public int Id { set; get; }
        public DateTime NgayGd { set; get; }
        public string ExternalTransactionId { set; get; }
        public float Amount { set; get; }
        public float Fee { set; get; }
        public string Result { set; get; }
        public string Message { set; get; }
        public TransactionStatus Status { set; get; }
        public string Provider { set; get; }

        public Guid UserId { get; set; }

        public AppUser AppUser { get; set; }

    }
}
