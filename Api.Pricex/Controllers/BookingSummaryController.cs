using Api.Pricex.Interface;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo;
using Api.Pricex.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class BookingSummaryController : Controller
    {
        private readonly pedb_devContext _dataContext;
        private readonly IPushNotificationService _pushNotificationService;
        public BookingSummaryController(pedb_devContext pedb_DevContext, IPushNotificationService pushNotificationService)
        {
            _dataContext = pedb_DevContext;
            _pushNotificationService = pushNotificationService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("bookingsummary")]
        //[Route("totaloffer")]
        public async Task<IActionResult> GetBookingSummary(string search, string search_type, int status, DateTime? date_from, DateTime? date_to)
        {
            try
            {
                BookingSummaryRepo repo = new BookingSummaryRepo(_dataContext);

                var result = repo.GetBookingSummary(search, search_type, status, date_from, date_to);

                if (result == null) return NotFound("Booking summary not found");

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [ActionName("bookingsummary")]
        [Route("{user_hotel_id}/action/{offer_id}")]
        public async Task<IActionResult> AcceptedOffer(int offer_id, string action, int user_hotel_id)
        {
            try
            {
                PushNotification notification = new PushNotification();
                BookingSummaryRepo repo = new BookingSummaryRepo(_dataContext);
                var result = "";
                if (action == "accept")
                {
                    result = await repo.AcceptOffer(offer_id);
                    if (result == null) return NotFound(new ResponseViewModel("Booking summary not found"));
                    //await _pushNotificationService.SendNotification(notification, user_hotel_id, "accept");
                }
                else if (action == "reject")
                {
                    result = await repo.RejectOffer(offer_id);
                    if (result == null) return NotFound(new ResponseViewModel("Booking summary not found"));
                    //await _pushNotificationService.SendNotification(notification, user_hotel_id, "reject");
                }

                return Ok(new ResponseViewModel(result));
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
