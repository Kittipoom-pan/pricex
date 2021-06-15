using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class OfferNotes
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public string Note { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
