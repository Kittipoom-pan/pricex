namespace Api.Pricex.ViewModels.CustomerService
{
    public class CustomerDetailViewModel
    {
        public int BookingId { get; set; }
        public int OfferId { get; set; }
        public string GuestName { get; set; }
        public string HotelName { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string EmailHotel { get; set; }
        public string PhoneHotel { get; set; }
        public int MemberId { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
