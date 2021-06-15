using Api.Pricex.Util;
using System;
using System.Globalization;

namespace Api.Pricex.myDB
{
    public partial class Invoices
    {
        public int Id { get; set; }
        public string InvoiceableId { get; set; }
        public string InvoiceableType { get; set; }
        public int UserId { get; set; }
        public string GatewayUrl { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
        public string Data { get; set; }
        public byte? ResultStatus { get; set; }
        public string ResultCallback { get; set; }
        public string IpAddress { get; set; }
        public string GateWay { get; set; }
        public string InvoiceNumber { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Invoice { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string GetStatus()
        {
            string result = "55555";
            if (this.ResultStatus == 1)
            {
                result = "Success";
            }
            else if (this.ResultStatus == 0)
            {
                result = "Pending";
            }
            return result;
        }

        public string GetDate()
        {
            //DateTime date = DateTime.ParseExact(CreatedAt, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //string dateText = CreatedAt.ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH"));
            string dateText = Utility.convertToDateTimeFormatString(CreatedAt.ToString());

            return dateText;
        }
    }
}
