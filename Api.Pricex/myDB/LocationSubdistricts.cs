using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class LocationSubdistricts
    {
        public string Id { get; set; }
        public int ZipCodeSuffix { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public int DistrictId { get; set; }
    }
}
