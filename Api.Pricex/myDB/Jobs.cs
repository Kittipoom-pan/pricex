using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Jobs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public byte Attempts { get; set; }
        public string ObjectType { get; set; }
        public int? ObjectRefId { get; set; }
        public int? ReservedAt { get; set; }
        public int AvailableAt { get; set; }
        public int CreatedAt { get; set; }
    }
}
