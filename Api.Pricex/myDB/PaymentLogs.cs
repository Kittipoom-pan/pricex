using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class PaymentLogs
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public string CardNo { get; set; }
        public string CardType { get; set; }
        public int ReferenceId { get; set; }
        public byte? Status { get; set; }
        public string Param { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
