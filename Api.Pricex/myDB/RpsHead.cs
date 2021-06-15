using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class RpsHead
    {
        public int Id { get; set; }
        public string ReportNo { get; set; }
        public string ReportName { get; set; }
        public string ReportDesc { get; set; }
        public int? LogoHiegth { get; set; }
        public string Sqlstring { get; set; }
        public string ReportTitle { get; set; }
        public string ReportSubTitle { get; set; }
        public string PeriodType { get; set; }
        public string DateFieldName { get; set; }
        public byte? UsesParameter { get; set; }
        public string ParamField { get; set; }
        public string ParamType { get; set; }
        public string ParamStr { get; set; }
        public string ParamListQry { get; set; }
        public byte? UseParam0 { get; set; }
        public string GroupField { get; set; }
        public string OrderedField { get; set; }
        public byte? IsIposFront { get; set; }
        public byte? IsLandscape { get; set; }
        public byte? IsShowRecno { get; set; }
        public byte? IsSubReport { get; set; }
        public string SqlSubdetail { get; set; }
        public string SubdetailDateFieldName { get; set; }
        public byte? UsesSubdetailParame { get; set; }
        public string SubdetailParamField { get; set; }
        public string SubdetailParamType { get; set; }
        public string SubdetailParamStr { get; set; }
        public string SubdetailParamListQry { get; set; }
        public byte? SubdetailUseParam0 { get; set; }
        public string SubdetailGroupfield { get; set; }
        public string SubdetailOrderfield { get; set; }
        public byte? GroupHeaderEnable { get; set; }
        public string DetailField { get; set; }
        public string MasterField { get; set; }
        public int? PaperSize { get; set; }
        public int? LeftMargin { get; set; }
        public int? RightMargin { get; set; }
        public int? FontSize { get; set; }
        public byte? IsG1 { get; set; }
        public byte? IsG2 { get; set; }
        public byte? IsG3 { get; set; }
        public byte? IsG4 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int? CreatedById { get; set; }
    }
}
