namespace Api.Pricex.ViewModels
{
    public class TransactionVenderViewModel
    {
        public int BookingId { get; set; }
        public int InvoiceId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TransactionTime { get; set; }
        public int TransactionAmount { get; set; }
        public int Commission { get; set; }
        public int OutStanding { get; set; }
        public string PaymentStatus { get; set; }
        public int TotalCommission { get; set; }
        public int TotalOutStanding { get; set; }
        public string Invoice { get; set; }
    }
}
