using Api.Pricex.myDB;
using Api.Pricex.Repo;
using Api.Pricex.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class UploadImageController : Controller
    {
        private readonly pedb_devContext _dataContext;
        private readonly IConfiguration _config;
        public UploadImageController(pedb_devContext pedb_DevContext, IConfiguration config)
        {
            _dataContext = pedb_DevContext;
            _config = config;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("uploadimage")]
        [Route("{reference_id}")]
        public async Task<IActionResult> UploadImage(List<IFormFile> Files, int reference_id, string category)
        {
            try
            {
                UploadImageRepo uploadImage = new UploadImageRepo(_dataContext, _config);

                var result = await uploadImage.UploadImageCenter(Files, category, reference_id);
                    
                if (result == null) return NotFound(new ResponseViewModel("Image not found"));

                return Json(new ResponseViewModel(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
