using System;

namespace Api.Pricex.ViewModels
{
    public class BookingSummaryViewModel
    {
        //public int BookingNo { get; set; }
        public int? OfferId { get; set; }
        public int? RoomNight { get; set; }
        public string OfferDate { get; set; }
        public string AcceptDate { get; set; }
        public string RoomType { get; set; }
        public int? TotalRooms { get; set; }
        public string CheckIn { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOut { get; set; }
        public string CheckOutTime { get; set; }
        public string Name { get; set; }
        public string OfferPrice { get; set; }
        public string FullPrice { get; set; }
        public string Status { get; set; }
    }
}
