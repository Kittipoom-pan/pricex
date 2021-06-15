using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class StdSysPriv
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SystemId { get; set; }
        public int AccessLevel { get; set; }
        public byte? CanRead { get; set; }
        public byte? CanWrite { get; set; }
        public byte? CanUseSpecial { get; set; }
    }
}
