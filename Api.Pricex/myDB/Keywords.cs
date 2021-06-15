using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Keywords
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
