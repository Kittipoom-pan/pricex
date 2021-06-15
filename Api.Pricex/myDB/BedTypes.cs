using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class BedTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public byte IsActive { get; set; }
    }
}
