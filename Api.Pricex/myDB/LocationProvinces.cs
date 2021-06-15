using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class LocationProvinces
    {
        public int Id { get; set; }
        public string ZipCodePrefix { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public int GeographyId { get; set; }
    }
}
