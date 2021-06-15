using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Favourites
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
