using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Hotels
    {
        public int Id { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public TimeSpan? CheckinTime { get; set; }
        public TimeSpan? CheckoutTime { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int HotelVoucherId { get; set; }
    }
}
