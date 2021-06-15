using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class OauthRefreshTokens
    {
        public string Id { get; set; }
        public string AccessTokenId { get; set; }
        public byte Revoked { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
