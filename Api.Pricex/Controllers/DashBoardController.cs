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
    public class DashBoardController : Controller
    {
        private readonly pedb_devContext _dataContext;
        public DashBoardController(pedb_devContext pedb_DevContext)
        {
            _dataContext = pedb_DevContext;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("dashboard")]
        [Route("totaloffers")]
        public async Task<IActionResult> GetTotalOffer(int hotel_branch_id,DateTime? date_from, DateTime? date_to)
        {
            try
            {
                DashboardRepo repo = new DashboardRepo(_dataContext);

                var result = repo.GetTotalOfferHotel(hotel_branch_id, date_from, date_to);

                if (result == null || result.Count == 0)
                    return NotFound(new ResponseViewModel("Total offer hotel not found"));
                
                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("dashboard")]
        [Route("pending")]
        public async Task<IActionResult> GetPendingDashboard(string duration, DateTime? calendar, int hotel_branch_id)
        {
            try
            {
                DashboardRepo repo = new DashboardRepo(_dataContext);

                //string token = Request.Headers.FirstOrDefault(x => x.Key == "token").Value.FirstOrDefault();

                var result = repo.GetPendingStatus(duration, calendar, hotel_branch_id);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Offer hotel not found"));

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("dashboard")]
        [Route("accepted")]
        public async Task<IActionResult> GetAcceptedDashboard(string search, string status, int hotel_branch_id)
        {
            try
            {
                DashboardRepo repo = new DashboardRepo(_dataContext);

                //string token = Request.Headers.FirstOrDefault(x => x.Key == "token").Value.FirstOrDefault();

                var result = repo.GetAcceptedStatus(search, status, hotel_branch_id);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Offer hotel not found"));

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("dashboard")]
        [Route("checkin")]
        public async Task<IActionResult> GetCheckInDashboard(string search, string status, int hotel_branch_id)
        {
            try
            {
                DashboardRepo repo = new DashboardRepo(_dataContext);

                //string token = Request.Headers.FirstOrDefault(x => x.Key == "token").Value.FirstOrDefault();

                var result = repo.GetCheckInStatus(search, status, hotel_branch_id);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Offer hotel not found"));

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("offerstatus")]
        //[Route("status")]
        public async Task<IActionResult> GetofferStatus()
        {
            try
            {
                var result = _dataContext.OfferStatuses.ToList();

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Offer status not found"));

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
