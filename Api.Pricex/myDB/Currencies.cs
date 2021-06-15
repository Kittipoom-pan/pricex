using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class Currencies
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FlagImg { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
