using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.myDB
{
    public partial class Rooms
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int HotelBranchId { get; set; }
        public string RoomTypeTh { get; set; }
        public string RoomTypeEn { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public string ShortDescriptionTh { get; set; }
        public string ShortDescriptionEn { get; set; }
        public int? MaxAdults { get; set; }
        public int? MaxChildren { get; set; }
        public string Detail { get; set; }
        public string Note { get; set; }
        public byte? IsRecommend { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int? RoomTypeId { get; set; }
        public string CancellationPolicy { get; set; }
        public string View { get; set; }
        public byte? IsBreakfast { get; set; }
        public byte? IsRoomOnly { get; set; }
        public int? RoomSize { get; set; }
        public int? ExtraBed { get; set; }
        [NotMapped]
        public ICollection<Photos> Photos { get; set; }
    }
}
