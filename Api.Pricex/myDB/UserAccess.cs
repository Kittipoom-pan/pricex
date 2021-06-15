using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.myDB
{
    public class UserAccess
    {
        public int UserAccessId { get; set; }
        public int UserGroupId { get; set; }
        public string AccessCode { get; set; }
        public string AccessPage { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
