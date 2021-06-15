using Api.Pricex.myDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.Models
{
    public class UserRegistration
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string HotelNameEn { get; set; }
        public string HotelNameTh { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Position { get; set; }
        [NotMapped]
        public TermAndConditionStampRead TermAndConditionStampRead { get; set; } = new TermAndConditionStampRead();
    }
}
