using Api.Pricex.Interface;
using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class LocationController : Controller
    {
        private readonly pedb_devContext _dataContext;
        private readonly ILocation _location;
        public LocationController(pedb_devContext pedb_DevContext, ILocation location)
        {
            _dataContext = pedb_DevContext;
            _location = location;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("province")]
        public async Task<IActionResult> GetProvince(string lang)
        {
            try
            {
                var result = await _location.GetProvince(lang);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Province not found"));
                
                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("district")]
        public async Task<IActionResult> GetDistrict(string lang, int provinceId)
        {
            try
            {
                var result = await _location.GetDistrict(lang, provinceId);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("District not found"));

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("sub-district")]
        public async Task<IActionResult> GetSubDistrict(string lang, int districtId)
        {
            try
            {
                var result = await _location.GetSubDistrict(lang, districtId);

                if (result == null || result.Count == 0) return NotFound(new ResponseViewModel("Sub District not found"));

                return Ok(result);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
