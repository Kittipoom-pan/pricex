namespace Api.Pricex.ViewModels.CustomerService
{
    public class BookingDetail : CustomerDetailViewModel
    {
        public int GuestPhone {get; set;}
        public int NumberOfNight {get; set;}
        public int NumberOfRoom { get; set;}
        public int NumberOfAdult { get; set;}
        public int NumberOfChidren { get; set;}
        public string CancellationPolicy { get; set;}
        public string RoomType { get; set;}
    }
}
