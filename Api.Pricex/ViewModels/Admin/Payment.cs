using System;

namespace Api.Pricex.ViewModels.Admin
{
    public class PaymentViewModel
    {
        public int BookingId { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public DateTime? TransactionTime { get; set; }
        public int TransactionAmount { get; set; }
        public int Commission { get; set; }
        public int CommissionAmount { get; set; }
        public int OutstandingBalance { get; set; }
        public int PaymentStatus { get; set; }
        public int TotalCommissionAmount { get; set; }
        public int TotalOutstanding { get; set; }
        public int OfferRate { get; set; }
        public int StandardRate { get; set; }
        public string PaymentMethod { get; set; }
        public string ImageAttachment { get; set; }
        public int ReferenceFrom { get; set; }
        public DateTime? OfferDate { get; set; }
        public int Amount { get; set; }
        public string RoomType { get; set; }
        public int RoomNight { get; set; }
        public int NumberOfRooms { get; set; }
        public int NoAdults { get; set; }
        public int NoChildren { get; set; }
        public string Position { get; set; }
        public string GeneralInformation { get; set; }
        public string Email { get; set; }
        public string AlternativeEmail { get; set; }
        public int Phone { get; set; }
    }
}
