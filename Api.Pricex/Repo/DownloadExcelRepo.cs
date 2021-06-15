using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo.Admin;
using Api.Pricex.ViewModels;
using ClosedXML.Excel;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class DownloadExcelRepo
    {
        public pedb_devContext _context { get; }
        private IConverter _converter;
        private IWebHostEnvironment _webHostEnvironment;
        public DownloadExcelRepo(pedb_devContext context, IConverter converter, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _converter = converter;
            _webHostEnvironment = webHostEnvironment;
        }

        public string DownloadCsv(Filter filter, string download_to)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (download_to == "Payment_Admin")
                {
                    stringBuilder.AppendLine($"Booking Id,Hotel Id,Hotel Name,Customer Name,Check In,Check Out" +
                        ",Transaction Time,Transaction Amount,Comm (%),COMM. Amount,Outstanding Balance,Payment Status");

                    PaymentRepo payment = new PaymentRepo(_context, _converter, _webHostEnvironment);
                    var model = payment.GetPayment(filter);

                    foreach (var data in model)
                    {
                        stringBuilder.AppendLine($"{data.BookingId},{ data.HotelId},{ data.HotelName},{ data.CustomerName},{ data.CheckIn},{ data.CheckOut}" +
                            $",{ data.TransactionTime},{ data.TransactionAmount},{ data.Commission},{ data.CommissionAmount},{ data.OutstandingBalance}" +
                            $",{ data.PaymentStatus}");
                    }

                    //var stream = new MemoryStream();
                    //using (var writeFile = new StreamWriter(stream, leaveOpen: true))
                    //{
                    //    var csv = new CsvWriter(writeFile, true);
                    //    csv.Configuration.RegisterClassMap<GroupReportCSVMap>();
                    //    csv.WriteRecords(reportCSVModels);
                    //}
                    //stream.Position = 0; //reset stream
                    //return File(stream, "application/octet-stream", "Reports.csv");
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DownloadExcel(Filter filter, string download_to)
        {
            string filePath = "";
            byte[] fileConent = { };
            string fileName = "";
            string folder = Path.Combine("upload", "excel", "download", download_to);
            //string newPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            string newPath = Path.Combine(Directory.GetCurrentDirectory(), folder);
            string fullPath = "";

            if (download_to == "Payment_Admin")
            {
                filePath = newPath;
                fileName = @"Payment_Report_" + Guid.NewGuid().ToString() + ".xlsx";
            }
            else if (download_to == "referral")
            {

            }

            try
            {
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(filePath);
                }

                fullPath = Path.Combine(newPath, fileName);

                int currentRow = 1;
                FileInfo file = new FileInfo(Path.Combine(newPath, fileName));
           
                using (var package = new ExcelPackage())
                {
                    //using (var stream = File.OpenRead(filePath))
                    //{
                    //    package.Load(stream);
                    //}
                    var ws = package.Workbook.Worksheets.Add("Sheet1");

                    PaymentRepo payment = new PaymentRepo(_context, _converter, _webHostEnvironment);
                    var model = payment.GetPayment(filter);
                
                    if (download_to == "Payment_Admin")
                    {
                        ws.Cells[1, 1].Value = "Booking Id";
                        ws.Cells[1, 2].Value = "Hotel Id";
                        ws.Cells[1, 3].Value = "Hotel Name";
                        ws.Cells[1, 4].Value = "Customer Name";
                        ws.Cells[1, 5].Value = "Check In";
                        ws.Cells[1, 6].Value = "Check Out";
                        ws.Cells[1, 7].Value = "Transaction Time";
                        ws.Cells[1, 8].Value = "Transaction Amount";
                        ws.Cells[1, 9].Value = "COMM.(%)";
                        ws.Cells[1, 10].Value = "COMM. Amount";
                        ws.Cells[1, 11].Value = "Outstanding Balance";
                        ws.Cells[1, 12].Value = "Payment Status";

                        foreach (var item in model)
                        {
                            currentRow++;
                            ws.Cells[currentRow, 1].Value = item.BookingId;
                            ws.Cells[currentRow, 2].Value = item.HotelId;
                            ws.Cells[currentRow, 3].Value = item.HotelName;
                            ws.Cells[currentRow, 4].Value = item.CustomerName;
                            ws.Cells[currentRow, 5].Value = item.CheckIn;
                            ws.Cells[currentRow, 6].Value = item.CheckOut;
                            ws.Cells[currentRow, 7].Value = item.TransactionTime;
                            ws.Cells[currentRow, 8].Value = item.TransactionAmount;
                            ws.Cells[currentRow, 9].Value = item.Commission;
                            ws.Cells[currentRow, 10].Value = item.CommissionAmount;
                            ws.Cells[currentRow, 11].Value = item.OutstandingBalance;
                            ws.Cells[currentRow, 12].Value = item.PaymentStatus;
                        }
                    }
                    else if (download_to == "referral")
                    {
                        //ws.Cells[5, 3].Value = onlineBookingExportExcelModel.title;
                    }
                    package.SaveAs(file);

                    fileConent = File.ReadAllBytes(file.ToString());
                    //using (MemoryStream stream = new MemoryStream()) //using System.IO;  
                    //{
                    //    wb.SaveAs(stream);
                    //    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelFile.xlsx");
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fullPath;
        }

        public ExcelFileViewModel DownloadExcelDocument(Filter filter, string v)
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            int currentRow = 1;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet ws =
                    workbook.Worksheets.Add("Sheet1");
                    ws.Cell(1, 1).Value = "Booking Id";
                    ws.Cell(1, 2).Value = "Hotel Id";
                    ws.Cell(1, 3).Value = "Hotel Name";
                    ws.Cell(1, 4).Value = "Customer Name";
                    ws.Cell(1, 5).Value = "Check In";
                    ws.Cell(1, 6).Value = "Check Out";
                    ws.Cell(1, 7).Value = "Transaction Time";
                    ws.Cell(1, 8).Value = "Transaction Amount";
                    ws.Cell(1, 9).Value = "COMM.(%)";
                    ws.Cell(1, 10).Value = "COMM. Amount";
                    ws.Cell(1, 11).Value = "Outstanding Balance";
                    ws.Cell(1, 12).Value = "Payment Status";

                    PaymentRepo payment = new PaymentRepo(_context, _converter, _webHostEnvironment);
                    var model = payment.GetPayment(filter);
                    foreach (var item in model)
                    {
                        currentRow++;
                        ws.Cell(currentRow, 1).Value = item.BookingId;
                        ws.Cell(currentRow, 2).Value = item.HotelId;
                        ws.Cell(currentRow, 3).Value = item.HotelName;
                        ws.Cell(currentRow, 4).Value = item.CustomerName;
                        ws.Cell(currentRow, 5).Value = item.CheckIn;
                        ws.Cell(currentRow, 6).Value = item.CheckOut;
                        ws.Cell(currentRow, 7).Value = item.TransactionTime;
                        ws.Cell(currentRow, 8).Value = item.TransactionAmount;
                        ws.Cell(currentRow, 9).Value = item.Commission;
                        ws.Cell(currentRow, 10).Value = item.CommissionAmount;
                        ws.Cell(currentRow, 11).Value = item.OutstandingBalance;
                        ws.Cell(currentRow, 12).Value = item.PaymentStatus;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        ExcelFileViewModel excelFile = new ExcelFileViewModel()
                        {
                            fileName = @"Payment_Report_" + Guid.NewGuid().ToString() + ".xlsx",
                            content = content,
                            contentType = contentType
                        };
                        return (excelFile);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
