using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Type
    {
        public int Id { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
