using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Migrations
    {
        public int Id { get; set; }
        public string Migration { get; set; }
        public int Batch { get; set; }
    }
}
