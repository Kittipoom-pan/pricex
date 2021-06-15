using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Devices
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceToken { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? RevokedAt { get; set; }
    }
}
