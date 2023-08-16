using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twilio.Jwt.AccessToken;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        private readonly FamilyEventContext _context;
        private readonly IConfiguration _config;
        private readonly IAccount _account;
        private readonly ITwillioService _twillioService;
        public TwilioController(ITwillioService twillioService,
                                     FamilyEventContext context,
                                     IConfiguration config,
                                     IAccount account)
        {
            _context = context;
            _config = config;
            this._account = account;
            this._twillioService = twillioService;
        }
        [HttpPost("sendOtp")]
        public async Task<IActionResult> SendOTP([FromBody] PhoneOtpRequest request)
        {
            var timeSendOtp = await _twillioService.SendOTP(request.PhoneNumber);
            return Ok(new { TimeSendOTP = timeSendOtp });
        }

        /// <summary>
        /// true: account chưa có
        /// false: account đã có rồi
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        [HttpPost("verifyOtp")]
        public async Task<IActionResult> VerifyOtp(string phoneNumber, string otp)
        {
            var status = await _twillioService.VerifyOTP(phoneNumber, otp);
            if (status == "approved")
            {
                var account = await this._context.Account
                .FirstOrDefaultAsync(x => x.Status && x.Phone == phoneNumber);

                bool isNewUser = false;

                if (account == null)
                {
                    account = new Account()
                    {
                        AccountId = "AId" + Guid.NewGuid().ToString().Substring(0,21),
                        Username = null,
                        Email = null,
                        Password = null,
                        Phone = phoneNumber,
                        Role = "eventBooker",
                        Status = true
                    };

                    _context.Add(account);
                    await _context.SaveChangesAsync();

                    isNewUser = true;
                }

                string jwtToken = _account.GenerateJSONWebToken(account);

                var response = new JwtTokenDto
                {
                    Username = account.Username,
                    Email = account.Email,
                    Phone = account.Phone,
                    jwtToken = jwtToken,
                    isNewUser = isNewUser
                };

                return Ok(response);
            }

            return Ok(new { Status = status });
        }

        public class PhoneOtpRequest
        {
            public string PhoneNumber { get; set; }
        }
    }
}
