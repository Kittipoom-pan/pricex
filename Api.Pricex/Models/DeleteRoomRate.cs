using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.Models
{
    public class DeleteRoomRate
    {
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Applicable { get; set; }
        public string ApplicableCustom { get; set; }
        public bool SpecificDay { get; set; }
        [NotMapped]
        public List<DayCustom> DayCustom { get; set; }
    }
    public class DayCustom
    {
        public string id { get; set; }
        public string day { get; set; }
    }
}
