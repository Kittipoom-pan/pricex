using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class HotelBranchConfigs
    {
        public int Id { get; set; }
        public int HotelBranchId { get; set; }
        public byte? RequireCheckinCode { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
