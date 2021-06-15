using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Versions
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public DateTimeOffset? ReleasedAt { get; set; }
        public string DeviceType { get; set; }
        public int? IsRequired { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string Detail { get; set; }
        public string StoreUrl { get; set; }
    }
}
