using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.myDB
{
    public class UserGroupAccess
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
