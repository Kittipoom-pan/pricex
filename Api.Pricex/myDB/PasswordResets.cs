using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class PasswordResets
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
