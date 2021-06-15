using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Pricex.myDB
{
    public class TermAndCondition
    {
        [Key]
        public int TermId { get; set; }
        public int? Version { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Content { get; set; }
    }
}
