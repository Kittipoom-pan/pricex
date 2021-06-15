using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class StdEmployee
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Nickname { get; set; }
        public string InitialName { get; set; }
        public DateTime? Birth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string PasswordCard { get; set; }
        public float? Salary { get; set; }
        public short? SalaryType { get; set; }
        public string Etype { get; set; }
        public string Edepartment { get; set; }
        public string Eposition { get; set; }
        public string EpositionDesc { get; set; }
        public int? Elevel { get; set; }
        public string CommentText { get; set; }
        public string IdcardNo { get; set; }
        public string SscardNo { get; set; }
        public string BankName { get; set; }
        public string BankAcc { get; set; }
        public byte[] Eimage { get; set; }
        public int? BranchId { get; set; }
        public int? StockLocationId { get; set; }
        public byte? IsSupervisor { get; set; }
        public byte? IsCashier { get; set; }
        public byte? IsManager { get; set; }
        public byte? IsServe { get; set; }
        public byte? CanOverride { get; set; }
        public byte? IsHeadoffice { get; set; }
        public byte? CanViewReport { get; set; }
        public byte? CanOc { get; set; }
        public byte? CanEnt { get; set; }
        public byte? CanCredit { get; set; }
        public TimeSpan? StdWorkIn { get; set; }
        public TimeSpan? StdWorkOut { get; set; }
        public byte? StdWorkOverDay { get; set; }
        public int? WorkingCalcType { get; set; }
        public byte? Enabled { get; set; }
        public string Tempdata1 { get; set; }
        public string Tempdata2 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? UpdatedById { get; set; }
    }
}
