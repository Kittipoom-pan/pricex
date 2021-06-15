using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class RoomFacilities
    {
        public int RoomId { get; set; }
        public int FacilityId { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
    }
}
