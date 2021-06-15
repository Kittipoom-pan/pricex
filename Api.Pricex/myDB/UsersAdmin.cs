using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class UsersAdmin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string DeviceType { get; set; }
        public string DeviceToken { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string AprovedBy { get; set; }
    }
}
