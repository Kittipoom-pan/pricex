using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class OauthPersonalAccessClients
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
