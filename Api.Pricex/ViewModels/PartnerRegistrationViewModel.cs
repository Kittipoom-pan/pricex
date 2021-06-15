namespace Api.Pricex.ViewModels
{
    public class PartnerRegistrationViewModel
    {
        public int UserId { get; set; }
        public int? HotelId { get; set; }
        public int? HotelBranchId { get; set; }
        public string HotelNameTh { get; set; }
        public string HotelNameEn { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string UserRegisterDate { get; set; }
        public int? UserStatus { get; set; }
        public int? HotelStatus { get; set; }
    }
}
