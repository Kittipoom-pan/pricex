using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.myDB
{
    public class RoomRateAllotment
    {
        public int Id { get; set; }
        public int HotelBranchId { get; set; }
        public int RoomId { get; set; }
        public int StatusId { get; set; }
        public bool SpecificDay { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Applicable { get; set; }
        public string ApplicableCustom { get; set; }
        public bool Allotment { get; set; }
        public int Amount { get; set; }
        public bool RoomOnly { get; set; }
        public int RoomOnlyPrice { get; set; }
        public bool IncludeBreakfast { get; set; }
        public int IncludeBreakfastPrice { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public int Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedFlag { get; set; }
        [NotMapped]
        public List<Room> Room { get; set; }
        [NotMapped]
        public List<DayCustom> DayCustom { get; set; }
    }
    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        //public List<DayCustom> DayCustom { get; set; }
    }
    public class DayCustom
    {
        public int id { get; set; }
        public string day { get; set; }
    }
}
