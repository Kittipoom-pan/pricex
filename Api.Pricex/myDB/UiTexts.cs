using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class UiTexts
    {
        public int Id { get; set; }
        public int UiKey { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string LanguageId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
