using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class PaymentRequestLog
    {
        public int Id { get; set; }
        public string Invoice { get; set; }
        public string RequestParams { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedIpAddress { get; set; }
    }
}
