namespace Api.Pricex.ViewModels
{
    public class RoomRateAllotmentViewModel
    {
        public int RoomId { get; set; }
        public int? HoteBranchId { get; set; }
        public int? StatusId { get; set; }
        public string Room { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public int? RoomForSale { get; set; }
        public int? NetBook { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string CreateAt { get; set; }
    }
}
