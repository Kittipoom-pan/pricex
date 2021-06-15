using Api.Pricex.Interface;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo;
using Api.Pricex.Repo.Admin;
using Api.Pricex.Util;
using Api.Pricex.ViewModels;
using AutoMapper;
using DinkToPdf.Contracts;
using EmailService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]

    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        ILogger<AdminController> _logger;
        private readonly pedb_devContext _dataContext;
        public Repo.Admin.DashboardRepo _dashboardRepo { get; }
        public Repo.Admin.HotelInfoRepo _hotelInfoRepo { get; }
        private IConverter _converter;
        private readonly IUserGroup _userGroup;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;

        public AdminController(pedb_devContext pedb_DevContext, Repo.Admin.DashboardRepo dashboardRepo, Repo.Admin.HotelInfoRepo hotelInfoRepo, IConverter converter, 
            IWebHostEnvironment webHostEnvironment, IMapper mapper, IUserGroup userGroup, IEmailSender emailSender)
        {
            _dataContext = pedb_DevContext;
            _dashboardRepo = dashboardRepo;
            _hotelInfoRepo = hotelInfoRepo;
            _converter = converter;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _userGroup = userGroup;
            _emailSender = emailSender;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("{user_id}/dashboard")]
        public async Task<IActionResult> Dashboard([FromQuery] Filter filter, int user_id)
        {
            try
            {
                string token = Request.Headers.FirstOrDefault(x => x.Key == "token").Value.FirstOrDefault();

                var result =_dashboardRepo.GetDashboard(filter, user_id);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Dashboard not found"));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("dashboard/total-offer")]
        public async Task<IActionResult> DashboardTotalOffer(DateTime? date_to, DateTime? date_from)
        {
            try
            {
                var result = _dashboardRepo.GetDashboardTotalOffer(date_to, date_from);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Dashboard not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("hotelinfo")]
        public async Task<IActionResult> HotelInfo([FromQuery] Filter filter)
        {
            try
            {
                //if (string.IsNullOrEmpty(filter.search))
                //{
                //    return Ok("Please complete all information.");
                //}

                var result = _hotelInfoRepo.GetHotelInfo(filter);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Hotel info not found"));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("hotelinfo/{id}/contactdetail")]
        public async Task<IActionResult> HotelInfoContactDetail(int id)
        {
            try
            {
                var result = (from h in _dataContext.Set<HotelBranches>()
                             join c in _dataContext.Set<ContactPerson>()
                             on h.HotelId equals c.HotelId
                             where h.HotelId == id
                             select new { position = c.Position, 
                                         responsibility = c.Responsibility, 
                                         phone = c.Phone, 
                                         email = c.Email, 
                                         alternativeEmail = c.AlternativeEmail,
                                         addressTH = h.AddressTh,
                                         addressEN = h.AddressEn,
                                        }).ToList();

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Contact detail not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("hotelinfo/transaction")]
        public async Task<IActionResult> HotelInfoTransaction([FromQuery] Filter filter)
        {
            try
            {
                HotelInfoTransactionRepo hotelInfo = new HotelInfoTransactionRepo(_dataContext);

                var result = hotelInfo.GetHotelInfoTransaction(filter);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Hotelinfo transaction not found"));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("offer/status")]
        public async Task<IActionResult> GetAllStatus()
        {
            try
            {
                var result = _dataContext.OfferStatuses.ToList();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Status not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("payment")]
        public async Task<IActionResult> GetPayment([FromQuery] Filter filter)
        {
            try
            {
                PaymentRepo payment = new PaymentRepo(_dataContext, _converter, _webHostEnvironment);

                var result = payment.GetAdminPayment(filter);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Payment not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("booking/{booking_id}/payment")]
        public async Task<IActionResult> GetUserPaymentByBooking(int booking_id)
        {
            try
            {
                PaymentRepo payment = new PaymentRepo(_dataContext, _converter, _webHostEnvironment);

                var result = await payment.GetUserPaymentByBookingId(booking_id);

                if (result == null)
                    return NotFound(new ResponseViewModel("Payment not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("payment/downloadpdf")]
        public IActionResult DownloadPdf([FromQuery] Filter filter)
        {
            PaymentRepo payment = new PaymentRepo(_dataContext, _converter, _webHostEnvironment);

            var file = payment.CreatePdf(filter, "payment");
            //return File(file, "application/pdf", "Payment_Report.pdf");
            return Ok(new { message = "Download pdf successfully" });
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("payment/downloadexcel")]
        public IActionResult DownloadExcel([FromQuery] Filter filter)
        {
            DownloadExcelRepo download = new DownloadExcelRepo(_dataContext, _converter, _webHostEnvironment);

            var content = download.DownloadExcelDocument(filter, "Payment_Admin");

            return File(content.content, content.contentType, content.fileName);
            //return Ok(new { path = filePath.Result });
            //return Ok("");
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("payment/downloadcsv")]
        public IActionResult DownloadCsv([FromQuery] Filter filter)
        {
            DownloadExcelRepo download = new DownloadExcelRepo(_dataContext, _converter, _webHostEnvironment);

            var data = download.DownloadCsv(filter, "Payment_Admin");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            var result = new FileStreamResult(stream, "text/plain");
            result.FileDownloadName = String.Format("Payment_Report_{0}.pdf", DateTime.Now.ToString("yyyyMMdd"));

            return File(Encoding.UTF8.GetBytes
            (data.ToString()), "text/csv", result.FileDownloadName);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("payment/{payment_id}/importpdf")]
        public async Task<IActionResult> ImportPdf(IFormFile file, int payment_id)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }

                ImportFileRepo import = new ImportFileRepo(_dataContext);

                var pathFolder = import.Import(file,payment_id, "payment_admin");
                var path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}:/{Url.Content(pathFolder.Result)}";

                return Ok(new { path });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("admin")]
        [Route("payment/{payment_id}/importexcel")]
        public async Task<IActionResult> ImportExcel(IFormFile file, int payment_id)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }
                ImportFileRepo import = new ImportFileRepo(_dataContext);

                var pathFolder = import.Import(file, payment_id, "payment_admin");
                var path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}:/{Url.Content(pathFolder.Result)}";

                return Ok(new { path });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("partner")]
        [Route("registration/hotel")]
        public async Task<IActionResult> PartnerRegistrationHotel()
        {
            try
            {
                var result = await (from h in _dataContext.HotelBranches
                                    join u in _dataContext.User 
                                    on h.Id equals u.HotelBranchId
                                    where u.StatusId == 1
                                    orderby h.CreatedAt descending
                              select new HotelRegistrationViewModel
                              {
                                  UserId = u.Id,
                                  UserName = u.Username,
                                  HotelBranchId = h.Id,
                                  HotelNameTh = h.NameTh,
                                  HotelNameEn = h.NameEn,
                                  HotelStatus = h.Status,
                                  HotelRegisterDate = Utility.convertToDateTimeFormatString(h.CreatedAt.ToString())
                              }).ToListAsync();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Hotel registration not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("partner")]
        [Route("registration/user")]
        public async Task<IActionResult> PartnerRegistrationUser()
        {
            try
            {
                var result = await (from u in _dataContext.User
                                    join h in _dataContext.Hotels
                                    on u.HotelId equals h.Id
                                    join hb in _dataContext.HotelBranches
                                    on h.Id equals hb.HotelId
                                    //where u.StatusId == 0
                                    orderby u.CreatedAt descending
                                    select new PartnerRegistrationViewModel
                                    {
                                        UserId = u.Id,
                                        HotelId = h.Id,
                                        HotelBranchId = u.HotelBranchId,
                                        HotelNameEn = h.NameEn,
                                        HotelNameTh = h.NameTh,
                                        UserName = u.Username,
                                        FirstName = u.FirstName,
                                        LastName = u.LastName,
                                        PhoneNumber = u.MobileNumber,
                                        Email = u.Email,
                                        Position = u.Position,
                                        UserStatus = u.StatusId,
                                        HotelStatus = hb.Status,
                                        UserRegisterDate = Utility.convertToDateTimeFormatString(u.CreatedAt.ToString())
                                    }).ToListAsync();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Partner registration not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("partner")]
        [Route("registration/user/{user_id}")]
        public async Task<IActionResult> PartnerRegistrationGetUserById(int user_id)
        {
            try
            {
                var result = await (from u in _dataContext.User
                                    join h in _dataContext.Hotels
                                    on u.HotelId equals h.Id
                                    where u.Id == user_id
                                    orderby u.CreatedAt descending
                                    select new PartnerRegistrationViewModel
                                    {
                                        UserId = u.Id,
                                        HotelBranchId = u.HotelBranchId,
                                        HotelNameEn = h.NameEn,
                                        HotelNameTh = h.NameTh,
                                        UserName = u.Username,
                                        FirstName = u.FirstName,
                                        LastName = u.LastName,
                                        PhoneNumber = u.MobileNumber,
                                        Email = u.Email,
                                        Position = u.Position,
                                        UserStatus = u.StatusId,
                                        UserRegisterDate = Utility.convertToDateTimeFormatString(u.CreatedAt.ToString())
                                    }).FirstOrDefaultAsync();

                if (result == null)
                    return NotFound(new ResponseViewModel("Partner registration not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = ex });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("partner")]
        [Route("registration/action")]
        public async Task<IActionResult> PartnerRegistrationAction(PartnerRegistrationAction action)
        {
            try
            {
                PartnerRegistrationActionRepo repo = new PartnerRegistrationActionRepo(_dataContext, _userGroup, _emailSender);

                (bool success, string result) = await repo.RegistrationAction(action);

                if (!success)
                    return Ok(new ResponseViewModel(result));

                return Ok(new ResponseViewModel(new { success = success, message = result }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = ex });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("registration")]
        [Route("hotel/action")]
        public async Task<IActionResult> HotelBranchAction(PartnerRegistrationAction action)
        {
            try
            {
                PartnerRegistrationActionRepo repo = new PartnerRegistrationActionRepo(_dataContext, _userGroup, _emailSender);

                (bool success, string result) = await repo.HotelBranchAction(action);

                if (!success)
                    return Ok(new ResponseViewModel(result));

                return Ok(new ResponseViewModel(new { success = success, message = result }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = ex });
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/commission")]
        public async Task<IActionResult> HotelBranchCommission(int hotel_branch_id, double commission)
        {
            try
            {
                PartnerRegistrationActionRepo repo = new PartnerRegistrationActionRepo(_dataContext, _userGroup, _emailSender);

                (bool success, string result) = await repo.AddCommission(hotel_branch_id, commission);

                if (!success)
                    return Ok(new ResponseViewModel(new { success = false }));

                return Ok(new ResponseViewModel(new { success = success, data = result }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = ex });
            }
        }
    }
}
