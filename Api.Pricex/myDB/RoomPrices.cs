using System;

namespace Api.Pricex.myDB
{
    public partial class RoomPrices
    {
        public int RoomId { get; set; }
        public DateTime RoomDate { get; set; }
        public int? Quota { get; set; }
        public int? HotelBranchId { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public short IsActive { get; set; }
        public int? RemainingQuota { get; set; }
    }
}
