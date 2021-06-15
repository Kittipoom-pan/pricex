using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class OfferRooms
    {
        public int OfferId { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
