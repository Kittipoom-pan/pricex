using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Coupons
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public string Type { get; set; }
        public int CampaignId { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public int? Maximum { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
