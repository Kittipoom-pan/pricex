namespace Api.Pricex.ViewModels
{
    public class HotelRegistrationViewModel
    {
        public int UserId { get; set; }
        public int? HotelBranchId { get; set; }
        public string HotelNameTh { get; set; }
        public string HotelNameEn { get; set; }
        public string UserName { get; set; }
        public string HotelRegisterDate { get; set; }
        public int? HotelStatus { get; set; }
    }
}
