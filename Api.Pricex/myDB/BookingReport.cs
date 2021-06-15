using Api.Pricex.Util;
using System;

namespace Api.Pricex.myDB
{
    public class BookingReport
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int Seq { get; set; }
        public string Activitie { get; set; }
        public string Review { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string GetDate()
        {
            string dateText = Utility.convertToDateTimeFormatString(CreatedAt.ToString());

            return dateText;
        }
    }
}
