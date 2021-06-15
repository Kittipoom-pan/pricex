using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
