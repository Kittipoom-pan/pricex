using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Ratings
    {
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public float? Rating { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
