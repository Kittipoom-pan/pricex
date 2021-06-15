namespace Api.Pricex.ViewModels
{
    public class UserAccessViewModels
    {
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public int? HotelId { get; set; }
        public int? HotelBranchId { get; set; }
        public string GroupType { get; set; }
        public string AccessCode { get; set; }
        public string AccessPage { get; set; }
        //public UserHotel UserHotel{ get; set; }
    }
    //public class UserHotel
    //{
    //    public int? HotelId { get; set; }
    //    public int? HotelBranchId { get; set; }
    //}
}
