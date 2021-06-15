using Api.Pricex.Interface;
using Api.Pricex.myDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class OfferPaymentController : Controller
    {
        private readonly pedb_devContext _dataContext;
        private readonly IOfferPayment _offerPayment;

        public OfferPaymentController(pedb_devContext pedb_DevContext, IOfferPayment offerPayment)
        {
            _dataContext = pedb_DevContext;
            _offerPayment = offerPayment;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("offer")]
        [Route("{offer_id}/payment-timeout")]
        public async Task<IActionResult> PaymentTimeout(int offer_id)
        {
            try
            {
                await _offerPayment.OfferPaymentTimeOut(offer_id);

                return Ok("");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
