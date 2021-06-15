using System;

namespace Api.Pricex.Models
{
    public class AmendBookingHotel
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string Hotel { get; set; }
        public string RoomType { get; set; }
        public int PhoneHotel { get; set; }
        public string EmailHotel { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int Night { get; set; }
        public int NumberOfRoom { get; set; }
        public int Adult { get; set; }
        public int Children { get; set; }
        public int IncludedBreakfast { get; set; }
        public string SpecialRequest { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

    }
}
