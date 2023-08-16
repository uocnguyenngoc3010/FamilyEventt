using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScriptController : ControllerBase
    {
        public IScript Service;

        public ScriptController(IScript service)
        {
            Service = service;
        }


        [Route("get-all-script")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Script>> responseAPI = new ResponseAPI<List<Script>>();
            try
            {
                responseAPI.Data = await this.Service.GetAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-name-script")]
        [HttpGet]
        public async Task<IActionResult> GetScriptByName(string name)
        {
            ResponseAPI<List<Script>> responseAPI = new ResponseAPI<List<Script>>();
            try
            {
                responseAPI.Data = await this.Service.GetScriptByName(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-id-script")]
        [HttpGet]
        public async Task<IActionResult> GetScriptById(string ID)
        {
            ResponseAPI<Script> responseAPI = new ResponseAPI<Script>();
            try
            {
                responseAPI.Data = await this.Service.GetScriptById(ID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }


        [Route("insert-script")]
        [HttpPost]
        public async Task<IActionResult> InsertScript(ScriptDto script)
        {
            ResponseAPI<List<Script>> responseAPI = new ResponseAPI<List<Script>>();
            try
            {
                responseAPI.Data = await this.Service.InsertScript(script);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("update-script")]
        [HttpPut]
        public async Task<IActionResult> UpdateScript(ScriptDto script)
        {
            ResponseAPI<List<Script>> responseAPI = new ResponseAPI<List<Script>>();
            try
            {
                responseAPI.Data = await this.Service.UpdateScript(script);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("delete-script")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDrink(string Id)
        {
            ResponseAPI<List<Script>> responseAPI = new ResponseAPI<List<Script>>();
            try
            {
                responseAPI.Data = await this.Service.DeleteScript(Id);
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
