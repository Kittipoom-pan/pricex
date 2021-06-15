using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.myDB
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }
        public int UserId { get; set; }
        public string GroupType { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
