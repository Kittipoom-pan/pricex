using System;

namespace Api.Pricex.ViewModels.Admin
{
    public class UserBookingPaymentViewModel
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public int RoomNight { get; set; }
        public int NumberOfRoom { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public string RoomType { get; set; }
        public string PaymentMethod { get; set; }
        public string From { get; set; }
        public string TransactionDate { get; set; }
        public int Amount { get; set; }
        public Decimal StandardRate { get; set; }
        public Decimal OfferRate { get; set; }
        public string Position { get; set; }
        public string GeneralInformation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AlternativeEmail { get; set; }
    }
}
