using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class UserRecentViews
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? UserId { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
    }
}
