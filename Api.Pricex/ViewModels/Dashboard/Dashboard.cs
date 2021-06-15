using System;

namespace Api.Pricex.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int Id { get; set; }
        public DateTime? OfferDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string RoomType { get; set; }
        public int? TotalRooms { get; set; }
        public int? TotalAdults { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string OfferPrice { get; set; }
        public string FullPrice { get; set; }
        public string Status { get; set; }
        public int? StatusId { get; set; }
        public int? WaitingTime { get; set; }
    }
}
