using System;

namespace Api.Pricex.myDB
{
    public class HotelVoucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public string DiscountType { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
