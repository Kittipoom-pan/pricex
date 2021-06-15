using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.myDB
{
    public class RoomSettingFoodAndDrink
    {
        public int Id { get; set; }
        public int HotelRoomSettingId { get; set; }
        public string DiningArea { get; set; }
        public string DiningTable { get; set; }
        public string FreeBottledWater { get; set; }
        public string ComplimentaryTeaAndCoffee { get; set; }
        public string CoffeeTeaMaker { get; set; }
        public string MiniBar { get; set; }
        public string Fruits { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
