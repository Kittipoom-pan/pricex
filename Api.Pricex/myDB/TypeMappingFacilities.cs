using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class TypeMappingFacilities
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int FacilitiesId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
