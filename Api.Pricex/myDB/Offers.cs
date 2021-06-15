using System;

namespace Api.Pricex.myDB
{
    public partial class Offers
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime? CheckedinAt { get; set; }
        public DateTime? CheckedoutAt { get; set; }
        public int TotalAdults { get; set; }
        public int TotalChildren { get; set; }
        public int TotalRooms { get; set; }
        public int TotalDays { get; set; }
        public decimal RoomAveragePrice { get; set; }
        public decimal OfferAveragePrice { get; set; }
        public int? WaitingTime { get; set; }
        public int CancelFlagId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedNote { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CanceledAt { get; set; }
        public string CanceledBy { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public string AcceptedBy { get; set; }
        public DateTime? PaymentExpiredAt { get; set; }
        public DateTime? RejectedAt { get; set; }
        public string RejectedBy { get; set; }
        public DateTime? PaidAt { get; set; }
        public string PaidBy { get; set; }
        public string PaidNote { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public int? BreakfastIncluded { get; set; }
        public int? ReasonRejectId { get; set; }
        public string SpecialRequest { get; set; }
        public string ReasonCancel { get; set; }

    }
}
