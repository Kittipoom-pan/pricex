using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class HotelLandmarks
    {
        public int HotelBranchId { get; set; }
        public int LandmarkId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
