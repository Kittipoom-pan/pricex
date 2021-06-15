using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Api.Pricex.myDB
{
    public class LocationLandmark
    {
            public int Id { get; set; }
            public int HotelBranchId { get; set; }
            public string Location { get; set; }
            public double Kilometer { get; set; }
            public DateTime? CreatedAt { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual HotelBranches HotelBranches { get; set; }
    }
}
