using System;

namespace Api.Pricex.myDB
{
    public class HotelRoomSetting
    {
        public int Id { get; set; }
        public int HotelBranchId { get; set; }
        public int HotelId { get; set; }
        public string Amenitie { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        //[NotMapped]
        //public ICollection<RoomSettingAmenities> RoomSettingAmenities { get; set; }
    }
}
