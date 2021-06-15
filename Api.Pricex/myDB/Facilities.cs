using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.myDB
{
    public partial class Facilities
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        [NotMapped]
        public ICollection<FacilitiesGroupType> FacilitiesGroupTypes { get; set; } = new List<FacilitiesGroupType>();
    }
}
