using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.myDB
{
    public partial class ContactPerson
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? HotelBranchId { get; set; }
        public int? UserId { get; set; }
        public string PreferName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Responsibility { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public string AlternativeEmail { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string CreatedBy { get; set; }     
        public DateTimeOffset? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

    }
}
