namespace Api.Pricex.Models
{
    public class PartnerRegistrationAction
    {
        public int UserId { get; set; }
        public int HotelBranchId { get; set; }
        public int UserAdminId { get; set; }
        public string Email { get; set; }
        //public string GroupType { get; set; }
        public string Action { get; set; }
        public string Link { get; set; }
    }
}
