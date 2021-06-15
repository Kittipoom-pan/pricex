
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Api.Pricex.myDB
{
    public partial class HotelBranches
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? UserId { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public string AddressTh { get; set; }
        public string AddressEn { get; set; }
        public string LandmarkTh { get; set; }
        public string LandmarkEn { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? SubDistrictId { get; set; }
        public string Tags { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public double? Rating { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        //public int LocationId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public bool IsAvailable { get; set; }
        //public string Location { get; set; }
        public double? Commission { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Status { get; set; }

        [NotMapped]
        public ICollection<LocationLandmark> Location_Landmark { get; set; } = new List<LocationLandmark>();
        [NotMapped]
        public ICollection<Photos> Photos { get; set; } = new List<Photos>();
    }
}
