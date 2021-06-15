using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class InvoiceCoupon
    {
        public string InvoiceId { get; set; }
        public int CouponId { get; set; }
        public decimal Discount { get; set; }
        public string DiscountType { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
