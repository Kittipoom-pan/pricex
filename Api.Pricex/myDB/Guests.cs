using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Guests
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public string Name { get; set; }
        public string CitizenId { get; set; }
        public string PassportId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
