using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Pricex.Models
{
    public class FacilitiesRequestModel
    {
        //public int facilities_id { get; set; }
        //public string topic_facilities { get; set; }

        //[JsonIgnore]
        //public string raw_facilities { get; set; }
        //public string facilities_group_type_id { get; set; }
        //public string facilities_group_type_name { get; set; }
        [NotMapped]
        public List<FacilitiesModel> facilities { get; set; }
        [NotMapped]
        public List<FacilitiesGroupModel> facilities_group { get; set; }
    }
    public class FacilitiesModel
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class FacilitiesGroupModel
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
