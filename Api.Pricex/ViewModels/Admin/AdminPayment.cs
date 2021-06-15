namespace Api.Pricex.ViewModels.Admin
{
    public class AdminPaymentViewModel
    {
        public int BookingId { get; set; }
        public int OfferId { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string CustomerName { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string TransactionTime { get; set; }
        public int TransactionAmount { get; set; }
        public int Commission { get; set; }
        public int CommissionAmount { get; set; }
        public int OutstandingBalance { get; set; }
        public string PaymentStatus { get; set; }
        public int Amount { get; set; }
        public int TotalCommissionAmount { get; set; }
        public int TotalOutstanding { get; set; }
    }
}
