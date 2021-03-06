using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Notifications
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int NotifiableId { get; set; }
        public string NotifiableType { get; set; }
        public string Data { get; set; }
        public DateTimeOffset? ReadAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
