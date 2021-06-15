using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.myDB
{
    public class CaseSummary
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int? Seq { get; set; }
        public string From { get; set; }
        public string Channel { get; set; }
        public string Note { get; set; }
        public string By { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
