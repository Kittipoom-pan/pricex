using System;

namespace Api.Pricex.myDB
{
    public class Payment
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public string  SwiftCode { get; set; }
        public string  Method { get; set; }
        public DateTime?  CreatedAt { get; set; }
        public string  CreatedBy { get; set; }
    }
}
