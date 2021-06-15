using System.ComponentModel.DataAnnotations;

namespace Api.Pricex.ViewModels.CustomerService
{
    public class BookingPaymentViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }
        public string Reference { get; set; }
        public string Currency { get; set; }
        public string GateWay { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Date")]
        public string Date { get; set; }
    }
}
