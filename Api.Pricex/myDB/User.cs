using System;

namespace Api.Pricex.myDB
{
    public partial class User
    {
        public int Id { get; set; }
        public int? HotelBranchId { get; set; }
        public int? HotelId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        public string CitizenId { get; set; }
        public string PassportId { get; set; }
        public string PreferName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Responsibility { get; set; }
        public string Gender { get; set; }
        public string AvatarProfileUrl { get; set; }
        public string Email { get; set; }
        public string AlternativeEmail { get; set; }
        public string MobileNumber { get; set; }
        public string Fax { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CityCode { get; set; }
        public string CountryCode { get; set; }
        public string FacebookId { get; set; }
        public DateTimeOffset? VerifiedAt { get; set; }
        public string RegisterType { get; set; }
        public string DeviceType { get; set; }
        public string DeviceToken { get; set; }
        public string RegisterKey { get; set; }
        public string CreatedIpAddress { get; set; }
        public string UpdatedIpAddress { get; set; }
        public string LanguageId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string FcmToken { get; set; }
        public int? HotelVoucherId { get; set; }
        public int? StatusId { get; set; }
    }
}
