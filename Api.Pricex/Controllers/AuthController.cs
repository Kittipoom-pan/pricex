using Api.Pricex.Configuration;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Repo;
using Api.Pricex.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class AuthController : ControllerBase
    {
        private readonly pedb_devContext _dataContext;
        private readonly IConfiguration _config;

        public AuthController(IOptionsMonitor<JwtConfig> optionsMonitor, pedb_devContext dataContext
            , IConfiguration config)
        {
            _dataContext = dataContext;
            _config = config;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistration user)
        {
            try
            {
                AuthRepo auth = new AuthRepo(_dataContext, _config);

                var data = await auth.Register(user);
                if (data == null)
                {
                    return BadRequest(new RegistrationViewModel()
                    {
                        Success = false,
                        Errors = new List<string>(){ "Email already exist" }
                    });
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private string GenerateJwtToken(IdentityUser user)
        //{
        //    var jwtTokenHandler = new JwtSecurityTokenHandler();

        //    var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim("Id", user.Id),
        //            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //            // the JTI is used for our refresh token which we will be convering in the next video
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        }),
        //        Expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtConfig.Expire)),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Sha256)
        //    };

        //    var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        //    var jwtToken = jwtTokenHandler.WriteToken(token);

        //    return jwtToken;
        //}

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ActionName("term-condition")]
        [Route("{user_id}")]
        public async Task<IActionResult> TermAndCondition([FromBody] TermAndConditionStampRead term)
        {
            try
            {
                //if(user_id == null || user_id == 0) return NotFound(new ResponseViewModel("User id not found"));

                var model = new TermAndConditionStampRead()
                {
                    UserId = term.UserId,
                    ReadFrom = term.ReadFrom,
                    ConfirmCheckbox = term.ConfirmCheckbox,
                    CreatedAt = DateTime.Now,
                };

                _dataContext.TermAndConditionStampRead.Add(model);
                _dataContext.SaveChanges();

                return Ok(new ResponseViewModel("Stamp term and condition successfully."));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ActionName("term-condition")]
        public async Task<IActionResult> GetTermAndCondition()
        {
            try
            {
                return Ok(_dataContext.TermAndCondition.Where(t => t.TermId == 1).FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
