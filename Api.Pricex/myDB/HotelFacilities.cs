using System;

namespace Api.Pricex.myDB
{
    public partial class HotelFacilities
    {
        public int Id { get; set; }
        public int HotelBranchId { get; set; }
        public int? UserId { get; set; }
        public string FacilitiesId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string FacilitiesGroupTypeId { get; set; }
    }
}
