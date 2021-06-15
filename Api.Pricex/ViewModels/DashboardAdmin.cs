

namespace Api.Pricex.ViewModels
{
    public class DashboardAdminViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int TotalRequest { get; set; }
        public int Pending { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Expire { get; set; }
        //public DateTime? CreateAt { get; set; }
    }
}
