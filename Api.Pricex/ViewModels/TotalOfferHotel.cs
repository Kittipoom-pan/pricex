
namespace Api.Pricex.ViewModels
{
    public class TotalOfferHotelViewModel
    {
        public int TotalOffer { get; set; }
        public int TotalPaidIncome { get; set; }
        public int TotalAccepted { get; set; }
        //public int HotelBranchId { get; set; }
        public string RoomType { get; set; }
        public string View { get; set; }
        public string HotelBranchName { get; set; }
        public string PhotoRoom { get; set; }
        //public string Currency { get; set; }
        public int OfferedPrice { get; set; }
        public int FullPrice { get; set; }
    }
}
