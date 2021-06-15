using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class LocationDistricts
    {
        public int Id { get; set; }
        public string ZipCodeBody { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public int ProvinceId { get; set; }
    }
}
