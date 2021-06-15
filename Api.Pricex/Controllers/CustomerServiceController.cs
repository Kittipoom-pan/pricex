using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo.CustomerService;
using Api.Pricex.Util;
using Api.Pricex.ViewModels;
using Api.Pricex.ViewModels.CustomerService;
using AutoMapper;
using EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class CustomerServiceController : Controller
    {
        private readonly pedb_devContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IOptions<EmailAccount> _emailAccount;
        public CustomerServiceController(pedb_devContext pedb_DevContext, IMapper mapper, IEmailSender emailSender, IOptions<EmailAccount> emailAccount)
        {
            _mapper = mapper;
            _dataContext = pedb_DevContext;
            _emailSender = emailSender;
            _emailAccount = emailAccount;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("customerdetail")]
        public async Task<IActionResult> GetCustomer([FromQuery] FilterCustomer filter)
        {
            try
            {
                CustomerDetailRepo customer = new CustomerDetailRepo(_dataContext);

                var result = customer.GetCustomerDetailByFilter(filter);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Customer not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/bookingsummary")]
        public async Task<IActionResult> GetBookingSummary(int booking_id)
        {
            try
            {
                CustomerDetailRepo customer = new CustomerDetailRepo(_dataContext);

                var result = customer.GetCustomerDetail(booking_id);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Booking hotel not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/bookinghotel")]
        public async Task<IActionResult> GetBookingHotel(int booking_id)
        {
            try
            {
                BookingHotelRepo bookingHotel = new BookingHotelRepo(_dataContext, _emailSender, _emailAccount);

                var result = (from f in _dataContext.Set<Offers>()
                              join b in _dataContext.Set<Bookings>()
                              on f.Id equals b.OfferId
                              join u in _dataContext.Set<Users>()
                              on f.UserId equals u.Id
                              join r in _dataContext.Set<Rooms>()
                              on f.RoomId equals r.Id
                              join h in _dataContext.Set<HotelBranches>()
                              on r.HotelBranchId equals h.Id
                              join cp in _dataContext.Set<ContactPerson>()
                              on h.Id equals cp.HotelId
                              where b.Id == booking_id
                              select new
                              {
                                  booking_id = b.Id,
                                  offer_id = f.Id,
                                  hotel = h.NameEn,
                                  room_type = r.RoomTypeEn,
                                  phone = h.PhoneNumber,
                                  email = h.Email,
                              }).FirstOrDefault();

                if (result == null)
                    return NotFound(new ResponseViewModel("Booking hotel not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/amendbookinghotel")]
        public async Task<IActionResult> GetAmendBookingHotel(int booking_id)
        {
            try
            {
                BookingHotelRepo bookingHotel = new BookingHotelRepo(_dataContext, _emailSender, _emailAccount);

                var result = (from f in _dataContext.Set<Offers>()
                              join b in _dataContext.Set<Bookings>()
                              on f.Id equals b.OfferId
                              join u in _dataContext.Set<Users>()
                              on f.UserId equals u.Id
                              join r in _dataContext.Set<Rooms>()
                              on f.RoomId equals r.Id
                              join h in _dataContext.Set<HotelBranches>()
                              on r.HotelBranchId equals h.Id
                              join cp in _dataContext.Set<ContactPerson>()
                              on h.Id equals cp.HotelId 
                              where b.Id == booking_id
                              select new
                              {
                                  offer_id = f.Id,
                                  booking_id = b.Id,
                                  number_of_night = f.TotalDays,
                                  number_of_room = f.TotalRooms,
                                  number_of_adult = f.TotalAdults,
                                  number_of_children = f.TotalChildren,
                                  checkin_date = Convert.ToDateTime(f.CheckedinAt).ToString("dd/MM/yyyy"),
                                  checkout_date = Convert.ToDateTime(f.CheckedoutAt).ToString("dd/MM/yyyy"),
                                  breakfast_included = f.BreakfastIncluded,
                                  special_request = f.SpecialRequest,
                                  hotel_name = h.NameEn,
                                  room_type = r.RoomTypeEn,
                                  phone = cp.Phone,
                                  email = cp.Email,
                              }).FirstOrDefault();

                if (result == null)
                     return NotFound(new ResponseViewModel("Booking hotel not found"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpPatch]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{user_id}/bookinghotel/{offer_id}/amend")]
        public async Task<IActionResult> EditBookingHotel(Offers offers, int offer_id, int user_id)
        {
            try
            {
                BookingHotelRepo bookingHotel = new BookingHotelRepo(_dataContext, _emailSender, _emailAccount);

                var result = await bookingHotel.EditBookingHotel(offers, offer_id, user_id);
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Booking hotel not found"));
                }
                return Ok(new { message = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{offer_id}/cancelbooking")]
        public async Task<IActionResult> CancelBooking(int offer_id, AmendBooking amend)
        {
            try
            {
                BookingHotelRepo bookingHotel = new BookingHotelRepo(_dataContext, _emailSender, _emailAccount);

                var result = await bookingHotel.CancelBooking(offer_id, amend.ReasonCancel);
                if (result == null)
                    return NotFound(new ResponseViewModel("Booking hotel not found"));
                
                return Ok(new { message = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpPatch]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{offer_id}/rejectbooking")]
        public async Task<IActionResult> RejectBooking(int offer_id, AmendBooking amend)
        {
            try
            {
                BookingHotelRepo bookingHotel = new BookingHotelRepo(_dataContext, _emailSender, _emailAccount);

                var result = await bookingHotel.RejectBooking(offer_id, amend.ReasonRejectId);
                if (result == null)
                    return NotFound(new ResponseViewModel("Booking hotel not found"));

                return Ok(new { message = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{offer_id}/bookingpayment/{booking_id}")]
        public async Task<IActionResult> GetBookingPayment(string offer_id, int booking_id)
        {
            try
            {   
                BookingPaymentRepo bookingPayment = new BookingPaymentRepo(_dataContext);

                var result = await bookingPayment.GetBookingPayment(offer_id, booking_id);

                if (result == null)
                    return NotFound(new ResponseViewModel("Booking payment not found"));
                
                BookingPaymentViewModel paymentViewModel = _mapper.Map<BookingPaymentViewModel>(result);

                return Ok(paymentViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{offer_id}/bookingpayment/update")]
        public async Task<IActionResult> BookingPayment(OfferPaymentTransactions model ,int offer_id)
        {
            try
            {
                BookingPaymentRepo bookingPayment = new BookingPaymentRepo(_dataContext);

                //var result = await bookingPayment.EditBookingPayment(model, offer_id);
                var result = "";
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Booking payment not found"));
                }
                return Ok(new { message = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/bookingreport")]
        public async Task<IActionResult> GetBookingReport(int booking_id)
        {
            try
            {
                BookingReportRepo bookingReport = new BookingReportRepo(_dataContext);

                var result = bookingReport.GetBookingReport(booking_id);

                if (result == null )
                {
                    return NotFound(new ResponseViewModel("Booking report not found"));
                }

                List<BookingReportViewMoel> bookingReportViewMoel = _mapper.Map<List<BookingReportViewMoel>>(result);

                return Ok(bookingReportViewMoel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/casesummary")]
        public async Task<IActionResult> GetAllCaseSummary(int booking_id)
        {
            try
            {
                CaseSummaryRepo caseSummary = new CaseSummaryRepo(_dataContext);

                var result = caseSummary.GetAllCaseSummary(booking_id);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Case summary not found"));
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/casesummary")]
        public async Task<IActionResult> AddCaseSummary(CaseSummary model, int booking_id)
        {
            try
            {
                CaseSummaryRepo caseSummary = new CaseSummaryRepo(_dataContext);

                var result = await caseSummary.AddCaseSummary(model, booking_id);
          
                return Ok(new { data = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("casesummary/{id}")]
        public async Task<IActionResult> EditCaseSummary(CaseSummary model, int id)
        {
            try
            {
                CaseSummaryRepo caseSummary = new CaseSummaryRepo(_dataContext);

                var result = await caseSummary.EditCaseSummary(model, id);
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Case summary not found"));
                }
                return Ok(new { data = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("{booking_id}/quicktool/changename")]
        public async Task<IActionResult> ChangeName(Bookings model, int booking_id)
        {
            try
            {
                QuickToolRepo quickTool = new QuickToolRepo(_dataContext);

                var result = await quickTool.ChangeName(model, booking_id);

                if (result == null) return NotFound(new ResponseViewModel("Booking not found"));

                return Ok(new { data = result });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("reason-reject")]
        public async Task<IActionResult> GetReasonReject()
        {
            try
            {
                return Json(_dataContext.ReasonReject.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }
    }
}
