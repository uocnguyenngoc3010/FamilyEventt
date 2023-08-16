using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminConfigController : ControllerBase
    {
        public IAdminConfig Service;
        public AdminConfigController(IAdminConfig service)
        {
            this.Service = service;
        }

        [Route("get-all-config")]
        [HttpGet]
        public async Task<IActionResult> GetAllAdmin()
        {
            ResponseAPI<AdminConfig> responseAPI = new ResponseAPI<AdminConfig>();
            try
            {
                responseAPI.Data = this.Service.GetConfig();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("change-config")]
        [HttpPut]
        public async Task<IActionResult> ChangeRule(AdminConfig config)
        {
            ResponseAPI<AdminConfig> responseAPI = new ResponseAPI<AdminConfig>();
            try
            {
                responseAPI.Data = this.Service.ChangeRule(config);
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
