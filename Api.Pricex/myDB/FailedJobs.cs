using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class FailedJobs
    {
        public int Id { get; set; }
        public string Connection { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public string Exception { get; set; }
        public DateTimeOffset FailedAt { get; set; }
    }
}
