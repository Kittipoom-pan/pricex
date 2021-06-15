using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Pricex.myDB
{
    public partial class FacilitiesGroupType
    {
        public int Id { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public int FacilitiesId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Facilities Facilities { get; set; }
    }
}
