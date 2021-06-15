using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Pricex.myDB
{
    public partial class HotelPayments
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int HotelBranchId { get; set; }
        public int? UserId { get; set; }
        //public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public string BankName { get; set; }
        //public string BankShortName { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolders { get; set; }
        public string BranchName { get; set; }
        //public string Currency { get; set; }
        public string SwiftCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
