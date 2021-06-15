using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Messages
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int UserCustomerId { get; set; }
        public int UserHotelId { get; set; }
        public int PhotoId { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
