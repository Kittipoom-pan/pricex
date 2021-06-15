using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class UserCoupon
    {
        public int CouponId { get; set; }
        public int UserId { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
