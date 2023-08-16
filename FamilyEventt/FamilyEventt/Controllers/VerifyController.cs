using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyController : ControllerBase
    {
        public IVerify Service;

        public VerifyController(IVerify service)
        {
            Service = service;
        }
        [Route("insert-verify")]
        [HttpPost]
        public async Task<IActionResult> InsertVerify(string eventid)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                responseAPI.Data = await this.Service.InsertVerifyCodeData(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("get-verifycode")]
        [HttpGet]
        public async Task<IActionResult> GetVerifyCodeEvent(string EventId)
        {
            ResponseAPI<Verify> responseAPI = new ResponseAPI<Verify>();
            try
            {
                responseAPI.Data = await this.Service.GetVerifyCodeEvent(EventId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-all-verifycode")]
        [HttpGet]
        public async Task<IActionResult> GetAllVerifyCode()
        {
            ResponseAPI<List<Verify>> responseAPI = new ResponseAPI<List<Verify>>();
            try
            {
                responseAPI.Data = await this.Service.GetAllVerify();
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
