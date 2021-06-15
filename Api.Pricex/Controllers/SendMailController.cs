using EmailService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Pricex.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class SendMailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public SendMailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("customerservice")]
        [Route("sendemail")]
        public async Task<IActionResult> SendEmail(Message message)
        {
            try
            {
                if (message.To == "") return Ok("Email not found");

                await _emailSender.SendEmailAsync(message);

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }
    }
}
