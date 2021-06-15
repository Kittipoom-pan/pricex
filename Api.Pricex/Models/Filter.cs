using System;

namespace Api.Pricex.Models
{
    public class Filter
    {
        public string search { get; set; }
        public string hotel_type { get; set; }
        public string status { get; set; }
        public string duration { get; set; }
        public DateTime? calendar { get; set; }
        public DateTime? date { get; set; }
    }
}
