using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Params { get; set; }
        public string Headers { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string IpAddress { get; set; }
    }
}
