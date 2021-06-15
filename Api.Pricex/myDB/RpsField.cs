using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class RpsField
    {
        public int Id { get; set; }
        public int? ReportHeadId { get; set; }
        public string DbfieldName { get; set; }
        public string ReportFieldName { get; set; }
        public int? FieldSize { get; set; }
        public string TextAlign { get; set; }
        public byte? HasSummary { get; set; }
        public string FormatText { get; set; }
        public int? Position { get; set; }
        public byte? IsSubdetail { get; set; }
    }
}
