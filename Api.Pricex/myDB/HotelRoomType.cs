using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.myDB
{
    public class HotelRoomType
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNameTh { get; set; }
        public string RoomNameEn { get; set; }
        public string RoomDetailTh { get; set; }
        public string RoomDetailEn { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public bool Breakfast { get; set; }
        public bool RoomOnly { get; set; }
        public int RoomSize { get; set; }
        public int ExtraBed { get; set; }
        public string View { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        [NotMapped]
        public ICollection<Photos> Photos { get; set; }
    }
}
