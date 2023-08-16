using BCrypt.Net;
using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly FamilyEventContext _context;
        private readonly IConfiguration _config;
        //private readonly ITwillioService _twillioService;
        private IAccount _accountService;
        public AccountController(IAccount accountService,
            FamilyEventContext context,
            IConfiguration config,
            ITwillioService twillioService)
        {
            this._accountService = accountService;
            _context = context;
            _config = config;
            
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Account>> responseAPI = new ResponseAPI<List<Account>>();
            try
            {
                responseAPI.Data = await this._accountService.GetAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        //<summary>
        // login username
        // </summary>
        // <param name="loginDto"></param>
        // <returns></returns>
       [HttpPost("login-username")]
        public async Task<IActionResult> Login([FromBody] AccountLoginDto loginDto)
        {
            var account = await _context.Account
                .FirstOrDefaultAsync(a => a.Username == loginDto.Username && a.Status);

            if (account == null)
            {
                return BadRequest("Tài Khoản Không Tồn Tại!");
            }
            if ((BCrypt.Net.BCrypt.Verify(loginDto.Password, account.Password)))
            {
                
            }
            else
            {
                return BadRequest("Mật Khẩu Không Chính Xác!");
            }
            
            /* if (account == null)
             {
                 return BadRequest("Tài Khoản Không Tồn Tại!");
             }

             if (account.Password != loginDto.Password)
             {
                 return BadRequest("Mật Khẩu Không Chính Xác!");
             }*/

            string token = _accountService.GenerateJSONWebToken(account);

            var response = new JwtTokenDto
            {
                accountid = account.AccountId,
                Username = account.Username,
                Email = account.Email,
                Phone = account.Phone,
                jwtToken = token
            };

            return Ok(response);
        }

        /*[Route("get-by-phone-number")]
        [HttpGet]
        public async Task<IActionResult> GetByNumberPhone(string phone)
        {
            ResponseAPI <Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.GetByNumberPhone(phone);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }*/

        //login bang mail
        //[HttpPost("phone/login")]
        //public async Task<IActionResult> LoginPhone([FromBody])
        //{
        //     check dung phone, dung otp, dung cmmj nua

        //    string token = _accountService.GenerateJSONWebToken(account);

        //    var response = new JwtTokenDto
        //    {
        //        Username = account.Username,
        //        Email = account.Email,
        //        Phone = account.Phone,
        //        jwtToken = token
        //    };

        //    return Ok(response);
        //}
        [HttpPost("login-staff")]
        public async Task<IActionResult> LoginStaff(string username, string password)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.LoginStaff(username, password);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpPost("register-staff")]
        public async Task<IActionResult> RegisterStaff(RegisterStaffDto newstaff)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.RegisterStaff(newstaff);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpPut("update-staff")]
        public async Task<IActionResult> UpdateStaff(UpdateStaffDto staff)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.UpdateStaff(staff);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        
        

        [HttpGet("get-staff-by-id")]
        public async Task<IActionResult> GetStaffById(string id)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.GetStaffByID(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpGet("get-staff-by-username")]
        public async Task<IActionResult> GetStaffByUsername(string username)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.GetStaffByUsername(username);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Id Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-staff-by-id")]
        public async Task<IActionResult> DeleteStaffById(string idStaff)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.DeleteStaffById(idStaff);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// User Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-staff-by-userName")]
        public async Task<IActionResult> DeleteStaff(string username)
        {
            ResponseAPI<Account> responseAPI = new ResponseAPI<Account>();
            try
            {
                responseAPI.Data = await this._accountService.DeleteStaff(username);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

    }
}
