using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.myDB
{
    public class HotelTransaction
    {
        public int Id { get; set; }
        public int HotelBranchId { get; set; }
        public string Customer { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string TransactionAmount { get; set; }
        public string Commission { get; set; }
        public string OutStanding { get; set; }
        public string PaymentStatus { get; set; }
        public string Invoice { get; set; }
        public string Params { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
