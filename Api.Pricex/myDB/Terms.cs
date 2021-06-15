using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Terms
    {
        public int Id { get; set; }
        public string LanguageId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
