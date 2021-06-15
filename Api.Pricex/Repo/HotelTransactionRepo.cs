using Api.Pricex.myDB;
using Api.Pricex.Util;
using Api.Pricex.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class HotelTransactionRepo
    {
        private readonly IConfiguration _config;
        private pedb_devContext dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelTransactionRepo(pedb_devContext dataContext, IConfiguration config)
        {
            this.dataContext = dataContext;
            _config = config;
        }

        public async Task<List<TransactionVenderViewModel>> GetTransactionHotel(string search, string search_by, DateTime? month, int hotel_branch_id)
        {
            try
            {
                var transaction = new List<TransactionVenderViewModel>();

                MySqlConnection conn = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_transaction_vender";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_search", search);
                    cmd.Parameters.AddWithValue("@input_month", month);
                    cmd.Parameters.AddWithValue("@input_search_by", search_by);
                    cmd.Parameters.AddWithValue("@input_hotel_branch_id", hotel_branch_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transaction.Add(new TransactionVenderViewModel()
                            {
                                BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                InvoiceId = reader["invoice_id"] != DBNull.Value ? Convert.ToInt32(reader["invoice_id"]) : 0,
                                Firstname = reader["first_name"].ToString(),
                                Lastname = reader["last_name"].ToString(),
                                TransactionTime = Utility.convertToDateTimeFormatString(reader["transaction_time"].ToString()),
                                PaymentStatus = reader["payment_status"].ToString(),
                                Invoice = reader["invoice"].ToString(),
                                TransactionAmount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
                                Commission = reader["commission"] != DBNull.Value ? Convert.ToInt32(reader["commission"]) : 0,
                                TotalCommission = reader["total_commission"] != DBNull.Value ? Convert.ToInt32(reader["total_commission"]) : 0,
                                OutStanding = reader["outstanding"] != DBNull.Value ? Convert.ToInt32(reader["outstanding"]) : 0,
                                TotalOutStanding = reader["total_outstanding"] != DBNull.Value ? Convert.ToInt32(reader["total_outstanding"]) : 0,
                            });
                        }
                    }
                    return transaction;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Export(string search, string search_by, DateTime? month, int hotel_branch_id)
        {
            string newPath = Path.Combine(_config.GetValue<string>("Resource:Env"), _config.GetValue<string>("Path:VenderTransactionPath"));

            string pathUpload = _config.GetValue<string>("PathUpload:VenderTransaction");

            if (!Directory.Exists(pathUpload))
            {
                Directory.CreateDirectory(pathUpload);
            }

            //string sFileName = @"Transaction_" + DateTime.Now.ToString("yyyyMMdd") + "-" + String.Format("{0:000}", Convert.ToInt32(hotel_branch_id)) + ".xlsx";

            string sFileName = Guid.NewGuid().ToString("N") + ".xlsx"; // unique name

            string URL = string.Format("{0}/{1}", newPath, sFileName);

            FileInfo file = new FileInfo(Path.Combine(pathUpload, sFileName));
            //if (file.Exists)
            //{
            //    file.Delete();
            //    file = new FileInfo(Path.Combine(newPath, sFileName));
            //}

            using (ExcelPackage package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Sheet1");
                int currentRow = 1;

                var model = await GetTransactionHotel(search, search_by, month, hotel_branch_id);

                ws.Cells[1, 1].Value = "Id";
                ws.Cells[1, 2].Value = "Customer";
                ws.Cells[1, 3].Value = "TransactionTime";
                ws.Cells[1, 4].Value = "TransactionAmount";
                ws.Cells[1, 5].Value = "Commission";
                ws.Cells[1, 6].Value = "OutStanding";
                ws.Cells[1, 7].Value = "PaymentStatus";

                foreach (var item in model)
                {
                    currentRow++;
                    ws.Cells[currentRow, 1].Value = item.BookingId;
                    ws.Cells[currentRow, 2].Value = string.Format("{0} {1}", item.Firstname, item.Lastname);
                    ws.Cells[currentRow, 3].Value = item.TransactionTime;
                    ws.Cells[currentRow, 4].Value = item.TransactionAmount;
                    ws.Cells[currentRow, 5].Value = item.Commission;
                    ws.Cells[currentRow, 6].Value = item.OutStanding;
                    ws.Cells[currentRow, 7].Value = item.PaymentStatus;
                }

                package.Save(); //Save the workbook.
            }

            return URL;
        }

        public List<HotelTransaction> GetTransactionForExportExcel(int hotel_branch_id)
        {
            return dataContext.HotelTransaction.Where(t => t.HotelBranchId == hotel_branch_id).ToList();
        }

        public async Task<Invoices> GetInvoice(int invoice_id)
        {
            // query แบบตัวเดียว
            return await dataContext.Invoices.Where(e => e.Id == invoice_id).FirstOrDefaultAsync();
        }

        public async Task<string> Import(int hotel_branch_id)
        {
            string sWebRootFolder = _config.GetValue<string>("ImportPathExcel:Path");
            string sFileName = @"demo.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            try
            {
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    bool bHeaderRow = true;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        for (int col = 1; col <= ColCount; col++)
                        {
                            if (bHeaderRow)
                            {
                                sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                            }
                            else
                            {
                                sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                            }
                        }
                        sb.Append(Environment.NewLine);
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "Some error occured while importing." + ex.Message;
            }
        }

        public async Task<(string,string)> ImportExcel(IFormFile reportfile, int invoice_id)
        {
            //string webRootPath = _config.GetValue<string>("Resource:Env");

            if (reportfile.Length > 0)
            {
                string folder = Path.Combine("upload", "excel");
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), folder);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                // Delete Files from Directory
                //System.IO.DirectoryInfo di = new DirectoryInfo(filePath);
                //foreach (FileInfo filesDelete in di.GetFiles())
                //{
                //    filesDelete.Delete();
                //}

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(reportfile.FileName);
                using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    reportfile.CopyTo(fileStream);
                }
                string path = Path.Combine("https://pricex-api.dev.fysvc.com", folder, fileName);
                return (path, fileName);
            }
            return (null, "");
        }

        public async Task UpdateInvoice(int invoice_id, string fileName)
        {
            var model = await GetInvoice(invoice_id);
            if (model != null)
            {
                model.Invoice = Path.Combine("upload", "excel", fileName);
                //model.PaymentStatus = "Complete";
                model.UpdatedAt = DateTime.Now;

                dataContext.Invoices.Update(model);
                dataContext.SaveChanges();
            }
        }

        public void ExportExcel(int hotel_branch_id)
        {
            string filePath = "";
            byte[] fileConent = { };
            string newFilePath = "";

            string folder = Path.Combine("excel", "download");
            string newPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            filePath = newPath;
            newFilePath = newPath;

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                using (var package = new ExcelPackage())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        package.Load(stream);
                    }
                    var ws = package.Workbook.Worksheets[1];

                    var model = GetTransactionForExportExcel(hotel_branch_id);

                    ws.Cells[1, 1].Value = "Id";
                    ws.Cells[1, 2].Value = "Customer";
                    ws.Cells[1, 3].Value = "TransactionTime";
                    ws.Cells[1, 4].Value = "TransactionAmount";
                    ws.Cells[1, 5].Value = "Commission";
                    ws.Cells[1, 6].Value = "OutStanding";
                    ws.Cells[1, 7].Value = "PaymentStatus";

                    //foreach (var item in model)
                    //{
                    //    currentRow++;
                    //    ws.Cells[currentRow, 1].Value = item.Id;
                    //    ws.Cells[currentRow, 2].Value = item.Customer;
                    //    ws.Cells[currentRow, 3].Value = item.TransactionTime;
                    //    ws.Cells[currentRow, 4].Value = item.TransactionAmount;
                    //    ws.Cells[currentRow, 5].Value = item.Commission;
                    //    ws.Cells[currentRow, 6].Value = item.OutStanding;
                    //    ws.Cells[currentRow, 7].Value = item.PaymentStatus;
                    //}

                    FileInfo file = new FileInfo(newFilePath);
                    package.SaveAs(file);

                    fileConent = File.ReadAllBytes(newFilePath);
                }
            }
            catch (Exception ex)
            {
                //LogManager.ServiceLog.WriteExceptionLog(ex, "Export Excel");
                throw ex;
            }
            //return fileConent;
        }

        //public string DownloadCsv(Filter filter, string download_to)
        //{
        //    try
        //    {
        //        StringBuilder stringBuilder = new StringBuilder();
        //        if (download_to == "Payment_Admin")
        //        {
        //            stringBuilder.AppendLine($"Booking Id,Hotel Id,Hotel Name,Customer Name,Check In,Check Out" +
        //                ",Transaction Time,Transaction Amount,Comm (%),COMM. Amount,Outstanding Balance,Payment Status");

        //            PaymentRepo payment = new PaymentRepo(_context, _converter, _webHostEnvironment);
        //            var model = payment.GetPayment(filter);

        //            foreach (var data in model)
        //            {
        //                stringBuilder.AppendLine($"{data.BookingId},{ data.HotelId},{ data.HotelName},{ data.CustomerName},{ data.CheckIn},{ data.CheckOut}" +
        //                    $",{ data.TransactionTime},{ data.TransactionAmount},{ data.Commission},{ data.CommissionAmount},{ data.OutstandingBalance}" +
        //                    $",{ data.PaymentStatus}");
        //            }
        //        }

        //        return stringBuilder.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<VenderTransactionViewModel> GetTransaction(Filter filter)
        //{
        //    try
        //    {
        //        var model = new List<VenderTransactionViewModel>();

        //        var month = filter.date.Month;
        //        var year = filter.date.Year;

        //        MySqlConnection conn = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);

        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            cmd.Connection = conn;
        //            conn.Open();
        //            cmd.CommandText = "get_admin_payment";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@input_search", filter.search);
        //            cmd.Parameters.AddWithValue("@input_month", month);

        //            cmd.Parameters.AddWithValue("@PageCount", MySqlDbType.Int32);
        //            cmd.Parameters["@PageCount"].Direction = ParameterDirection.Output;

        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    model.Add(new VenderTransactionViewModel()
        //                    {
        //                        Id = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
        //                        HotelId = reader["hotel_id"] != DBNull.Value ? Convert.ToInt32(reader["hotel_id"]) : 0,
        //                        HotelName = reader["name_en"].ToString(),
        //                        CustomerName = reader["customer_name"].ToString(),
        //                        CheckIn = reader.IsDBNull("customer_checkin_at") ? (DateTime?)null : reader.GetDateTime("customer_checkin_at"),
        //                        CheckOut = reader.IsDBNull("customer_checkout_at") ? (DateTime?)null : reader.GetDateTime("customer_checkout_at"),
        //                        TransactionTime = reader.IsDBNull("transaction_time") ? (DateTime?)null : reader.GetDateTime("transaction_time"),
        //                        TransactionAmount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
        //                        Commission = reader["commission"] != DBNull.Value ? Convert.ToInt32(reader["commission"]) : 0,
        //                        CommissionAmount = reader["commission_amount"] != DBNull.Value ? Convert.ToInt32(reader["commission_amount"]) : 0,
        //                        TotalCommission = reader["total_comm_amount"] != DBNull.Value ? Convert.ToInt32(reader["total_comm_amount"]) : 0,
        //                        OutstandingBalance = reader["outstanding"] != DBNull.Value ? Convert.ToInt32(reader["outstanding"]) : 0,
        //                        TotalOutstanding = reader["total_outstanding"] != DBNull.Value ? Convert.ToInt32(reader["total_outstanding"]) : 0,
        //                        PaymentStatus = reader["status"] != DBNull.Value ? Convert.ToInt32(reader["status"]) : 0,
        //                        OfferRate = reader["offer_average_price"] != DBNull.Value ? Convert.ToInt32(reader["offer_average_price"]) : 0,
        //                        StandardRate = reader["room_average_price"] != DBNull.Value ? Convert.ToInt32(reader["room_average_price"]) : 0,
        //                        PaymentMethod = reader["payment_type"].ToString(),
        //                        ImageAttachment = reader["image_attachment"].ToString(),
        //                        ReferenceFrom = reader["reference"] != DBNull.Value ? Convert.ToInt32(reader["reference"]) : 0,
        //                        Amount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
        //                        RoomType = reader["room_type_en"].ToString(),
        //                        RoomNight = reader["total_days"] != DBNull.Value ? Convert.ToInt32(reader["total_days"]) : 0,
        //                        NumberOfRooms = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
        //                        NoAdults = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0,
        //                        NoChildren = reader["total_children"] != DBNull.Value ? Convert.ToInt32(reader["total_children"]) : 0,
        //                        Position = reader["position"].ToString(),
        //                        GeneralInformation = reader["responsibilities"].ToString(),
        //                        Email = reader["email"].ToString(),
        //                        AlternativeEmail = reader["alternative_email"].ToString(),
        //                        Phone = reader["phone"] != DBNull.Value ? Convert.ToInt32(reader["phone"]) : 0,
        //                    });
        //                }
        //            }
        //            conn.Close();
        //            return model;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
