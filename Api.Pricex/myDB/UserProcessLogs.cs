using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class UserProcessLogs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Log { get; set; }
        public string Param { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
