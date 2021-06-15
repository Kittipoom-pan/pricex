using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Campaigns
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime ExpiredAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
