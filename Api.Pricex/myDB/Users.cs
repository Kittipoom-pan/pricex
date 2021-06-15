using System;

namespace Api.Pricex.myDB
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CitizenId { get; set; }
        public string PassportId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AvatarProfileUrl { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }
        public string CountryCode { get; set; }
        public string FacebookId { get; set; }
        public DateTimeOffset? VerifiedAt { get; set; }
        public string RegisterType { get; set; }
        public string DeviceId { get; set; }
        public string ClientId { get; set; }
        public string RegisterKey { get; set; }
        public string RememberToken { get; set; }
        public string CreatedIpAddress { get; set; }
        public string UpdatedIpAddress { get; set; }
        public string LanguageId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
