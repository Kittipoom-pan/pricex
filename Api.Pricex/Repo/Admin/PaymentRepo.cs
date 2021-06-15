using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Util;
using Api.Pricex.ViewModels.Admin;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Api.Pricex.Repo.Admin
{
    public class PaymentRepo
    {
        public pedb_devContext _context { get; }
        private IConverter _converter;
        private IWebHostEnvironment _webHostEnvironment;
        public PaymentRepo(pedb_devContext context, IConverter converter, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _converter = converter;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<PaymentViewModel> GetPayment(Filter filter)
        {
            try
            {
                var model = new List<PaymentViewModel>();

                //var month = filter.date.Month;
                //var year = filter.date.Year;

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_admin_payment";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_search", filter.search);
                    cmd.Parameters.AddWithValue("@input_month", filter.date);
                    cmd.Parameters.AddWithValue("@input_status", filter.status);
                    cmd.Parameters.AddWithValue("@input_hotel_type", filter.hotel_type);

                    cmd.Parameters.AddWithValue("@PageCount", MySqlDbType.Int32);
                    cmd.Parameters["@PageCount"].Direction = ParameterDirection.Output;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new PaymentViewModel()
                            {
                                BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                HotelId = reader["hotel_id"] != DBNull.Value ? Convert.ToInt32(reader["hotel_id"]) : 0,
                                HotelName = reader["name_en"].ToString(),
                                CustomerName = reader["customer_name"].ToString(),
                                CheckIn = reader.IsDBNull("customer_checkin_at") ? (DateTime?)null : reader.GetDateTime("customer_checkin_at"),
                                CheckOut = reader.IsDBNull("customer_checkout_at") ? (DateTime?)null : reader.GetDateTime("customer_checkout_at"),
                                TransactionTime = reader.IsDBNull("transaction_time") ? (DateTime?)null : reader.GetDateTime("transaction_time"),
                                TransactionAmount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
                                Commission = reader["commission"] != DBNull.Value ? Convert.ToInt32(reader["commission"]) : 0,
                                CommissionAmount = reader["commission_amount"] != DBNull.Value ? Convert.ToInt32(reader["commission_amount"]) : 0,
                                TotalCommissionAmount = reader["total_comm_amount"] != DBNull.Value ? Convert.ToInt32(reader["total_comm_amount"]) : 0,
                                OutstandingBalance = reader["outstanding"] != DBNull.Value ? Convert.ToInt32(reader["outstanding"]) : 0,
                                TotalOutstanding = reader["total_outstanding"] != DBNull.Value ? Convert.ToInt32(reader["total_outstanding"]) : 0,
                                PaymentStatus = reader["status"] != DBNull.Value ? Convert.ToInt32(reader["status"]) : 0,
                                OfferRate = reader["offer_average_price"] != DBNull.Value ? Convert.ToInt32(reader["offer_average_price"]) : 0,
                                StandardRate = reader["room_average_price"] != DBNull.Value ? Convert.ToInt32(reader["room_average_price"]) : 0,
                                PaymentMethod = reader["payment_type"].ToString(),
                                ImageAttachment = reader["image_attachment"].ToString(),
                                ReferenceFrom = reader["reference"] != DBNull.Value ? Convert.ToInt32(reader["reference"]) : 0,
                                Amount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
                                RoomType = reader["room_type_en"].ToString(),
                                RoomNight = reader["total_days"] != DBNull.Value ? Convert.ToInt32(reader["total_days"]) : 0,
                                NumberOfRooms = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
                                NoAdults = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0,
                                NoChildren = reader["total_children"] != DBNull.Value ? Convert.ToInt32(reader["total_children"]) : 0,
                                Position = reader["position"].ToString(),
                                GeneralInformation = reader["responsibilities"].ToString(),
                                Email = reader["email"].ToString(),
                                AlternativeEmail = reader["alternative_email"].ToString(),
                                Phone = reader["phone"] != DBNull.Value ? Convert.ToInt32(reader["phone"]) : 0,
                            });
                        }
                    }
                    conn.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPdfTemplate(Filter filter)
        {
            var payment = GetPayment(filter);

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Report</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Booking Id</th>
                                   
                                        <th>Hotel Id</th>
                                        <th>Hotel Name</th>
                                        <th>Customer Name</th>
                                        <th>Check In</th>
                                        <th>Check Out</th>
                                        <th>Transaction Time</th>
                                        <th>Transaction Amount</th>
                                        <th>Comm. (%)</th>
                                        <th>Comm. Amount (%)</th>
                                        <th>Outstanding Balance</th>
                                        <th>Payment Status</th>
                                    </tr>");

            foreach (var data in payment)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td>{8}</td>
                                    <td>{9}</td>
                                    <td>{10}</td>
                                    <td>{11}</td>
                                  </tr>
                                  <tr>
                                    <td>Total</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>{12}</td>
                                    <td>{13}</td>
                                    <td></td>
                                   </tr>", data.BookingId, data.HotelId, data.HotelName, data.CustomerName, data.CheckIn, data.CheckOut, data.TransactionTime
                                         , data.TransactionAmount, data.Commission, data.CommissionAmount, data.OutstandingBalance, data.PaymentStatus
                                         , data.TotalCommissionAmount, data.TotalOutstanding);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public byte[] CreatePdf(Filter filter, string page)
        {
            string folder = Path.Combine(page);

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, @"pdf\download", folder);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fileName = String.Format("Payment_Report_{0}.pdf", DateTime.Now.ToString("yyyyMMdd"));

            string fullPath = Path.Combine(filePath, fileName);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = fullPath
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetPdfTemplate(filter),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return file;
        }

        //public WebReport GetReport()
        //{
        //    string webRootPath = _webHostEnvironment.WebRootPath; // Get the path to the wwwroot folder
        //    WebReport webReport = new WebReport(); // Create a Web Report Object
        //    webReport.Report.Load(webRootPath + "/reports/Master-Detail.frx"); // Load the report into the WebReport object
        //    var dataSet = new DataSet(); // Create a data source
        //    dataSet.ReadXml(webRootPath + "/reports/nwind.xml"); // Open the xml database
        //    webReport.Report.RegisterData(dataSet, "NorthWind"); // Register the data source in the report
        //    return webReport;
        //}

        public List<AdminPaymentViewModel> GetAdminPayment(Filter filter)
        {
            try
            {
                var model = new List<AdminPaymentViewModel>();

                //var month = filter.date.Month;
                //var year = filter.date.Year;

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_admin_payment";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_search", filter.search);
                    cmd.Parameters.AddWithValue("@input_month", filter.date);
                    cmd.Parameters.AddWithValue("@input_status", filter.status);
                    cmd.Parameters.AddWithValue("@input_hotel_type", filter.hotel_type);

                    cmd.Parameters.AddWithValue("@PageCount", MySqlDbType.Int32);
                    cmd.Parameters["@PageCount"].Direction = ParameterDirection.Output;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new AdminPaymentViewModel()
                            {
                                BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                OfferId = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                HotelId = reader["hotel_id"] != DBNull.Value ? Convert.ToInt32(reader["hotel_id"]) : 0,
                                HotelName = reader["name_en"].ToString(),
                                CustomerName = reader["customer_name"].ToString(),
                                CheckIn = reader.GetDateTime("checkedin_at").ToString("dd/MM/yyyy"),
                                CheckOut = reader.GetDateTime("checkedout_at").ToString("dd/MM/yyyy"),
                                //CheckOut = reader.IsDBNull("checkedout_at") ? (DateTime?)null : reader.GetDateTime("checkedout_at"),
                                TransactionTime = reader.GetDateTime("transaction_time").ToString("dd/MM/yyyy HH:mm:ss"),
                                TransactionAmount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
                                Commission = 0,
                                CommissionAmount = 0,
                                TotalCommissionAmount = 0,
                                OutstandingBalance = 0,
                                TotalOutstanding = 0,
                                PaymentStatus = reader["payment_status"].ToString(),
                                Amount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0,
                            });
                        }
                    }
                    conn.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserBookingPaymentViewModel> GetUserPaymentByBookingId(int booking_id)
        {
            try
            {
                var model = new UserBookingPaymentViewModel();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_admin_payment_by_bookingid";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pBookingID", booking_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0;
                            model.OfferRate = reader["offer_average_price"] != DBNull.Value ? Convert.ToInt32(reader["offer_average_price"]) : 0;
                            model.StandardRate = reader["room_average_price"] != DBNull.Value ? Convert.ToInt32(reader["room_average_price"]) : 0;
                            model.PaymentMethod = reader["payment_method"].ToString();
                            model.From = reader["card_number"].ToString();
                            model.TransactionDate = Utility.convertToDateTimeFormatString(reader.GetDateTime("transaction_time").ToString());
                            model.Amount = reader["amount"] != DBNull.Value ? Convert.ToInt32(reader["amount"]) : 0;
                            model.CustomerName = reader["customer_name"].ToString();
                            model.RoomType = reader["room_type_en"].ToString();
                            model.Arrival = Utility.convertToDateFormatString(reader.GetDateTime("arrival").ToString());
                            model.Departure = Utility.convertToDateFormatString(reader.GetDateTime("departure").ToString());
                            model.RoomNight = reader["room_night"] != DBNull.Value ? Convert.ToInt32(reader["room_night"]) : 0;
                            model.NumberOfChildren = reader["total_children"] != DBNull.Value ? Convert.ToInt32(reader["room_night"]) : 0;
                            model.NumberOfAdult = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0;
                            model.NumberOfRoom = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0;
                            model.GeneralInformation = reader["responsibilities"].ToString();
                            model.Email = reader["email"].ToString();
                            model.AlternativeEmail = reader["alternative_email"].ToString();
                            model.Phone = reader["phone"].ToString();
                            model.Position = reader["position"].ToString();
                        }
                    }
                    conn.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
