using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.Models
{
    public class RoomSetting
    {
        [NotMapped]
        public List<RoomSettingAmenitie> roomSettingAmenitie { get; set; }
    }
    public class RoomSettingAmenitie
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<Room> room { get; set; }
    }
    public class Room
    {
        public string id { get; set; }
        public string room { get; set; }

    }
}
