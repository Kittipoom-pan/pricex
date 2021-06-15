using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Languages
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
