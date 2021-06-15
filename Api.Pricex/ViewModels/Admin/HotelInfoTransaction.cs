using System;

namespace Api.Pricex.ViewModels.Admin
{
    public class HotelInfoTransactionViewModel
    {
        public int BookingId { get; set; }
        public int OfferId { get; set; }
        public string HotelName { get; set; }
        public string CustomerName { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public int RoomNight { get; set; }
        public string RoomType { get; set; }
        public Decimal OriginalRate { get; set; }
        public Decimal OfferRate { get; set; }
        public int WaitingTime { get; set; }
        public string OfferRateDate { get; set; }
        public string OfferExpiredAt { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public string GeneralInformation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AlternativeEmail { get; set; }
    }
}
