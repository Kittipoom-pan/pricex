using System;

namespace Api.Pricex.myDB
{
    public partial class OfferPaymentTransactions
    {
        public int Id { get; set; }
        public string Invoice { get; set; }
        public int OfferId { get; set; }
        public int? Commission { get; set; }
        public double Amount { get; set; }
        public string Params { get; set; }
        public string RequestIpAddress { get; set; }
        public string CallbackCardType { get; set; }
        public string CallbackCardNumber { get; set; }
        public string CallbackIpAddress { get; set; }
        public string CallbackParams { get; set; }
        public DateTimeOffset? CallbackCreatedAt { get; set; }
        public byte? Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int? Seq { get; set; }
        public string TransactionType { get; set; }
        public string PaymentType { get; set; }
        public int? Reference { get; set; }
        public string Currency { get; set; }
        public string GateWay { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
