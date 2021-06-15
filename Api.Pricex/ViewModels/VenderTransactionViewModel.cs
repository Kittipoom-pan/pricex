namespace Api.Pricex.ViewModels
{
    public class VenderTransactionViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string TransactionTime { get; set; }
        public int TransactionAmount { get; set; }
        public int Commission { get; set; }
        public int Outstanding { get; set; }
        public int PaymentStatus { get; set; }
        public int TotalCommission { get; set; }
        public int TotalOutstanding { get; set; }
    }
}
