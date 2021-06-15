using System;

namespace Api.Pricex.myDB
{
    public partial class Bookings
    {
        public int Id { get; set; }
        public int? OfferId { get; set; }
        public int? UserId { get; set; }
        public string PaymentId { get; set; }
        public string Code { get; set; }
        public string CheckinCode { get; set; }
        public DateTimeOffset? CustomerCheckinAt { get; set; }
        public DateTimeOffset? CustomerCheckoutAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Memo { get; set; }
        public int? BookingStatusId { get; set; }
        public int? ReasonRejectId { get; set; }
        public int? ReasonCancelId { get; set; }
        public DateTimeOffset? RejectedAt { get; set; }
        public string RejectedBy { get; set; }
        public DateTimeOffset? CanceledAt { get; set; }
        public string CanceledBy { get; set; }
        public string LeadGuestName { get; set; }
        public string Surname { get; set; }
    }
}
