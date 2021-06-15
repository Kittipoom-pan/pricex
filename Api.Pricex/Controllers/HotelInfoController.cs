using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo;
using Api.Pricex.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]

    public class HotelInfoController : Controller
    {
        ILogger<HotelInfoController> _logger;
        private readonly pedb_devContext _dataContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public HotelInfoController(pedb_devContext pedb_DevContext, IConfiguration config, IHostingEnvironment hostingEnvironment, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _dataContext = pedb_DevContext;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            // _logger = logger
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("login")]
        //[Route("login")]
        public async Task<IActionResult> Login(UserViewModels user)
        {
            try
            {
                AuthRepo auth = new AuthRepo(_dataContext, _config);

                var access = auth.Login(user);

                if (access == null || access.Count == 0)
                    return Unauthorized(new { data = "Username not found" }); 
                
                return Ok(new { data = "Login success.",access });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_id}/allpropertydetail")]
        public async Task<IActionResult> GetAllHotelBranchByHotel(int hotel_id)
        {
            try
            {
                var result = _dataContext.HotelBranches
                               .Where(q => q.HotelId == hotel_id)
                               .Include(p => p.Photos)
                               .Include(l => l.Location_Landmark)
                               .ToList();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Hotel branch not found"));


                result.ForEach(q =>
                {
                    q.Photos = q.Photos.Where(c => c.Type == "hotel_branch").ToList();
                    
                    foreach (var item in q.Photos)
                    {
                        //item.Path = Path.Combine(_config.GetValue<string>("Resource:Env"), item.Path);
                        item.Path = string.Format("{0}/{1}",_config.GetValue<string>("Resource:Env"), item.Path);
                    }
                });

                //var ef =  _dataContext.HotelBranches.Where(q => q.HotelId == hotel_id).Include(x => x.Photos).ProjectTo<PhotoViewModels>(_mapper.ConfigurationProvider).ToList();

                //List<PhotoViewModels> rtn = _mapper.Map<List<PhotoViewModels>>(ef);
                
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_id}/hotelbranch/{hotel_branch_id}/detail/{user_id}")]
        public async Task<IActionResult> AddHotelBranchDetail([FromForm] HotelBranches hotelBranches, int hotel_id, List<IFormFile> Files,int hotel_branch_id, int user_id)
        {
            try
            {
                HotelInfoRepo hotelInfo = new HotelInfoRepo(_dataContext, _config, _webHostEnvironment);
          
                (int hotelBranchId, string result) = await hotelInfo.AddHotelDetail(hotelBranches, hotel_id, Files, hotel_branch_id, user_id);

                if (hotelBranchId == 0) return NotFound(new { hotelBranchId = hotelBranchId, data = result });

                return Ok(new { HotelBranchId = hotelBranchId ,data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/propertydetail")]
        public async Task<IActionResult> GetHotelBranchById(int hotel_branch_id)
        {
            try
            {
                var result = _dataContext.HotelBranches
                               .Where(q => q.Id == hotel_branch_id)
                               .Include(p => p.Photos)
                               .Include(l => l.Location_Landmark)
                               .ToList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Hotel branch not found"));
                }

                result.ForEach(q =>
                {
                    q.Photos = q.Photos.Where(c => c.Type == "hotel_branch").ToList();

                    foreach (var item in q.Photos)
                    {
                        //item.Path = Path.Combine(_config.GetValue<string>("Resource:Env"), item.Path);
                        item.Path = string.Format("{0}/{1}", _config.GetValue<string>("Resource:Env"), item.Path);
                    }
                });

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("propertydetail/location/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var result = await _dataContext.LocationLandmarks.FindAsync(id);

                if (result == null)
                    return NotFound(new ResponseViewModel("Location landmark not found"));

                _dataContext.LocationLandmarks.Remove(result);
                await _dataContext.SaveChangesAsync();

                return Json(new ResponseViewModel("Delete location landmark successfully."));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [ActionName("delete-image")]
        [Route("{id}")]
        public async Task<IActionResult> UploadImage(int id)
        {
            try
            {
                UploadImageRepo uploadImage = new UploadImageRepo(_dataContext, _config);

                var result = await uploadImage.DeleteImage(id);

                if (result == 0) return NotFound(new ResponseViewModel("Image not found"));

                return Json(new ResponseViewModel("Delete image successfully."));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("{hotel_branch_id}/allpayment")]
        public async Task<IActionResult> GetAllPayment(int hotel_branch_id)
        {
            try
            {
                var result = _dataContext.HotelPayments.Where(p => p.HotelBranchId == hotel_branch_id).ToList();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Payment not found"));
                
                return Json(new ResponseViewModel(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("payment/{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var result = await _dataContext.HotelPayments.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (result == null) return NotFound(new ResponseViewModel("Payment not found"));
                
                return Json(new ResponseViewModel(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_id}/hotel-branch/{hotel_branch_id}/payment/{user_id}")]
        public async Task<IActionResult> AddPayment([FromForm] HotelPayments hotelPayments, int hotel_id, int hotel_branch_id, int user_id)
        {
            try
            {
                //if (hotelPayments == null || hotelPayments.PaymentMethod == null)
                //{
                //    throw new Exception("Not found form-data.");
                //}

                HotelInfoRepo hotelInfo = new HotelInfoRepo(_dataContext, _config, _webHostEnvironment);

                var result = await hotelInfo.AddPayment(hotelPayments, hotel_id, hotel_branch_id, user_id);

                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("{id}/payment/update")]
        public async Task<IActionResult> EditPayment([FromForm] HotelPayments payment, int id)
        {
            try
            {
                HotelInfoRepo hotelInfo = new HotelInfoRepo(_dataContext, _config, _webHostEnvironment);

                var result = await hotelInfo.EditPayment(payment, id);
                if (result == null)
                    return NotFound(new ResponseViewModel("Payment not found"));
                
                return Ok(new { result = result, message = "Update payment successfully" });
            }
            catch (Exception error)
            {
                _logger.LogError($"Log Payment Update : {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_branch_id}/facilities/{user_id}")]
        public async Task<IActionResult> UpdateHotelFacilities(int hotel_branch_id, FacilitiesRequestModel facilities, int user_id)
        {
            try
            {
                HotelFacilitiesRepo hotelInfo = new HotelFacilitiesRepo(_dataContext, _config);

                var result = await hotelInfo.UpdateHotelFacilities(hotel_branch_id, facilities, user_id);

                return Ok(new ResponseViewModel(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_branch_id}/facilities")]
        public async Task<IActionResult> GetFacilities(int hotel_branch_id)
        {
            try
            {
                var result = await _dataContext.Facilities
                               .Include(p => p.FacilitiesGroupTypes)
                               .ToListAsync();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Facilities not found"));
                }

                //result.ForEach(q =>
                //{
                //    q.Photos = q.Photos.Where(c => c.Type == "property_detail").ToList();

                //    foreach (var item in q.Photos)
                //    {
                //        var pathName = "images/" + item.Type + "/" + item.Filename;
                //        item.Path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}:/{Url.Content(pathName)}";
                //    }
                //});
                
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/facilities")]
        public async Task<IActionResult> GetHotelFacilities(int hotel_branch_id)
        {
            try
            {
                var result = await _dataContext.HotelFacilities
                               .Where(c => c.HotelBranchId == hotel_branch_id)
                               .ToListAsync();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Hotel facilities not found"));
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_id}/roomtype/{hotel_branch_id}/")]
        public async Task<IActionResult> AddRoomType([FromForm] Rooms hotelRoomType, int hotel_id, int hotel_branch_id, List<IFormFile> Files)
        {
            try
            {
                HotelRoomTypeRepo roomType = new HotelRoomTypeRepo(_dataContext, _config, _webHostEnvironment);

                var (data,result) = await roomType.AddRoomType(hotelRoomType, hotel_id, hotel_branch_id, Files);

                if (data == 400) return BadRequest(new ResponseViewModel(result));

                return Ok(new { roomId = data , message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_branch_id}/allroomtype")]
        public async Task<IActionResult> GetRoomType(int hotel_branch_id)
        {
            try
            {
                var result = _dataContext.Rooms.Where(q => q.HotelBranchId == hotel_branch_id).Include(q => q.Photos).ToList();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Hotel room type not found"));

                result.ForEach(q =>
                {
                    q.Photos = q.Photos.Where(c => c.Type == "room_type").ToList();


                    foreach (var item in q.Photos)
                    {
                        item.Path = string.Format("{0}/{1}", _config.GetValue<string>("Resource:Env"), item.Path);
                    }
                });
  
                //var view = _mapper.Map<PhotoViewModels>(result);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("roomtype/{id}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            try
            {
                HotelRoomTypeRepo hotelInfo = new HotelRoomTypeRepo(_dataContext, _config, _webHostEnvironment);

                var result = await _dataContext.Rooms.Where(e => e.Id == id).Include(q => q.Photos).ToListAsync();

                if (result == null)
                {
                    return NotFound("Hotel room type not found");
                }

                result.ForEach(q =>
                {
                    q.Photos = q.Photos.Where(c => c.Type == "room_type").ToList();


                    foreach (var item in q.Photos)
                    {
                        var pathName = "images/" + item.Type + "/" + item.Filename;
                        //item.Path = Path.Combine(_config.GetValue<string>("Resource:Env"), item.Path);
                        item.Path = string.Format("{0}/{1}", _config.GetValue<string>("Resource:Env"), item.Path);
                    }
                });

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("roomtype/{id}")]
        public async Task<IActionResult> EditRoomType([FromForm] Rooms room, int id, List<IFormFile> Files)
        {
            try
            {
                HotelRoomTypeRepo hotelInfo = new HotelRoomTypeRepo(_dataContext, _config, _webHostEnvironment);

                var (data,result) = await hotelInfo.EditRoomType(room, id, Files);

                if (data == 400)
                    return BadRequest(result);
                
                return Ok(new { roomId = data ,message = result });
            }
            catch (Exception error)
            {
                _logger.LogError($"Log UpdateProduct: {error}");
                return StatusCode(500, new { message = error });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("{hotel_id}/contactperson/{hotel_branch_id}")]
        public async Task<IActionResult> AddContactPerson([FromForm] ContactPerson contactPerson, IFormFile Files, int hotel_id, int hotel_branch_id)
        {
            try
            {

                ContactPersonRepo person = new ContactPersonRepo(_dataContext, _config, _webHostEnvironment);

                var result = await person.AddContactPerson(contactPerson, Files, hotel_id, hotel_branch_id);

                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("{id}/contactperson/update")]
        public async Task<IActionResult> EditContactPerson([FromForm] ContactPerson contactPerson, int id, IFormFile Files)
        {
            try
            {
                ContactPersonRepo person = new ContactPersonRepo(_dataContext, _config, _webHostEnvironment);

                var result = await person.EditContactPerson(contactPerson, id, Files);
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Person not found"));
                }
                return Ok(new { result = result, message = "Update person successfully" });
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("{hotel_branch_id}/allcontactperson")]
        public async Task<IActionResult> GetAllContactPerson(int hotel_branch_id)
        {
            try
            {
                var result = _dataContext.ContactPerson.Where(c => c.HotelBranchId == hotel_branch_id).ToList();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Person not found"));

                //return File($"~/images/{"16b53a5d-aaca-46d7-9e26-3af96fb83820.jpg"}", "image/jpg");

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("contactperson/{id}")]
        public async Task<IActionResult> GetContactPerson(int id)
        {
            try
            {
                var result = await _dataContext.ContactPerson.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (result == null)
                    return NotFound(new ResponseViewModel("Person not found"));

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_id}/hotelbranch/{hotel_branch_id}/roomsetting")]
        public async Task<IActionResult> AddRoomSetting(RoomSetting roomSetting, int hotel_id, int hotel_branch_id)
        {
            try
            {
                if (roomSetting.roomSettingAmenitie == null) return BadRequest("Data not null");

                HotelRoomSettingRepo repo = new HotelRoomSettingRepo(_dataContext, _config);

                var result = await repo.UpdateRoomSetting(roomSetting, hotel_id, hotel_branch_id);

                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("roomsetting")]
        public async Task<IActionResult> GetRoomsetting()
        {
            try
            {
                var result = await _dataContext.RoomSettingAmenities
                                       .ToListAsync();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Room setting not found"));

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/roomsetting")]
        public async Task<IActionResult> GetRoomsettingByHotel(int hotel_branch_id)
        {
            try
            {
                var result = await _dataContext.HotelRoomSettings.Where(e => e.HotelBranchId == hotel_branch_id).ToListAsync();

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Room setting not found"));

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_branch_id}/transaction")]
        public async Task<IActionResult> GetTransaction(string search, string search_by, int hotel_branch_id, DateTime? month)
        {
            try
            {
                HotelTransactionRepo repo = new HotelTransactionRepo(_dataContext, _config);

                var result = await repo.GetTransactionHotel(search,search_by, month,hotel_branch_id);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Transaction not found"));
                
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("hotelinfo")]
        [Route("{hotel_branch_id}/transaction/downloadexcel")]
        public async Task<IActionResult> DownloadExcelFile(string search, string search_by, DateTime? month, int hotel_branch_id)
        {
            try
            {
                HotelTransactionRepo repo = new HotelTransactionRepo(_dataContext, _config);

                var url = await repo.Export(search,search_by, month ,hotel_branch_id);

                return Ok(new { data = url });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet]
        //[MapToApiVersion("1.0")]
        //[ActionName("hotel")]
        //[Route("transaction/downloadcsv")]
        //public IActionResult DownloadCsv([FromQuery] Filter filter)
        //{
        //    HotelTransactionRepo repo = new HotelTransactionRepo(_dataContext, _config);

        //    var data = repo.DownloadCsv(filter, "Payment_Admin");

        //    var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
        //    var result = new FileStreamResult(stream, "text/plain");
        //    result.FileDownloadName = String.Format("Payment_Report_{0}.pdf", DateTime.Now.ToString("yyyyMMdd"));

        //    return File(Encoding.UTF8.GetBytes
        //    (data.ToString()), "text/csv", result.FileDownloadName);
        //}


        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("import-invoice")]
        //[Route("{id}/transaction/import-invoice")]
        public async Task<IActionResult> ImportExcelFile(IFormFile file, int invoice_id)
        {
            try
            {
                HotelTransactionRepo repo = new HotelTransactionRepo(_dataContext, _config);

                (string result,string filename) = await repo.ImportExcel(file, invoice_id);
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Hotel Transaction not found"));
                }

                await repo.UpdateInvoice(invoice_id,filename);

                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("hotel")]
        [Route("{hotel_branch_id}/roomrate/createrate")]
        public async Task<IActionResult> CreateNewRate(RoomRateAllotment roomRate ,int hotel_branch_id)
        {
            try
            {
                RoomRateAllotmentRepo repo = new RoomRateAllotmentRepo(_dataContext);

                var result = await repo.CreateRoomRate(roomRate, hotel_branch_id);

                return Ok(new ResponseViewModel(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/roomrate/resetrate")]
        public async Task<IActionResult> ResetRoomRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            try
            {
                RoomRateAllotmentRepo repo = new RoomRateAllotmentRepo(_dataContext);

                var result = await repo.EditRoomRate(roomRate, hotel_branch_id);
                if (!result)
                {
                    return NotFound(new ResponseViewModel("Room not found"));
                }
                return Ok(new { data = "Reset room rate successfully" });
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/roomrate/resetpricerate")]
        public async Task<IActionResult> ResetPriceRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            try
            {
                RoomRateAllotmentRepo repo = new RoomRateAllotmentRepo(_dataContext);

                var result = await repo.EditPriceRate(roomRate, hotel_branch_id);
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Room not found"));
                }
                return Ok(new { data = "Reset price rate successfully" });
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("hotelbranch")]
        [Route("{hotel_branch_id}/roomrate/deleterate")]
        public async Task<IActionResult> DeleteRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            try
            {
                RoomRateAllotmentRepo repo = new RoomRateAllotmentRepo(_dataContext);

                var result = await repo.DeleteRate(roomRate, hotel_branch_id);
                if (result == null)
                {
                    return NotFound(new ResponseViewModel("Room not found"));
                }
                return Ok(new { data = "Delete rate successfully" });
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("room")]
        [Route("{hotel_branch_id}")]
        public async Task<IActionResult> GetRoomAsync(int hotel_branch_id, string lang)
        {
            try
            {
                RoomRateAllotmentRepo repo = new RoomRateAllotmentRepo(_dataContext);

                var result = await repo.Getroom(hotel_branch_id, lang);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Room not found"));
                
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError($"Log GetRoom: {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("roomrate-allotment")]
        [Route("{hotel_branch_id}")]
        public async Task<IActionResult> GetRoomrateAllotment(int hotel_branch_id, int room_id, string lang, DateTime? date_from, DateTime? date_to)
        {
            try
            {
                RoomRateAllotmentRepo repo = new RoomRateAllotmentRepo(_dataContext);

                var result = await repo.GetRoomrateAllotment(hotel_branch_id, room_id, lang, date_from, date_to);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new ResponseViewModel("Room not found"));
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError($"Log GetRoomrate: {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("bank-name")]
        public IActionResult GetBankName()
        {
            try
            {
                var result = _dataContext.BankName.ToList();

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Bank name not found"));
                
                return Ok(new ResponseViewModel(result));
            }
            catch (Exception error)
            {
                _logger.LogError($"Log Get Bank Name: {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }
    }
}
