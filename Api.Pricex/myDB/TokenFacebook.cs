using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class TokenFacebook
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string FacebookId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
