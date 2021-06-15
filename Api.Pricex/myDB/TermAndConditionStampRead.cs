using System;

namespace Api.Pricex.myDB
{
    public class TermAndConditionStampRead
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool ConfirmCheckbox { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ReadFrom { get; set; }
        public int TermId { get; set; }
        public int Version { get; set; }
    }
}
