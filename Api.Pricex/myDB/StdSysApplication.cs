using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class StdSysApplication
    {
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public DateTime? AppReleaseDate { get; set; }
        public byte[] AppLogo { get; set; }
        public byte[] AppBarBanner { get; set; }
        public string ShopName { get; set; }
        public string BranchName { get; set; }
        public string NsisContactInfo { get; set; }
        public byte[] NsisLogo { get; set; }
        public string NsisFullName { get; set; }
        public string NsisFullAddress { get; set; }
        public string NsisFullNameEn { get; set; }
        public string NsisFullAddressEn { get; set; }
        public string NsisTel { get; set; }
        public string NsisEmail { get; set; }
        public string NsisWeb { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerFullNameEn { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress1En { get; set; }
        public string CustomerAddress2En { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerFax { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerWeb { get; set; }
        public string CustomerShortName { get; set; }
        public string CustomerTaxNo { get; set; }
        public string ParamNameList { get; set; }
    }
}
