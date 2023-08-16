using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntertainmentController : ControllerBase
    {
        public IEntertainment EntertainmentServices;
        public EntertainmentController(IEntertainment  _entertainment)
        {
            EntertainmentServices = _entertainment;
        }

        [Route("get-all-entertainment")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Entertainment>> responseAPI = new ResponseAPI<List<Entertainment>>();
            try
            {
                responseAPI.Data = await this.EntertainmentServices.GetAllEntertainments();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// search by id Entertainment
        /// </summary>
        /// <returns></returns>
        [Route("get-by-id-Entertainment")]
        [HttpGet]
        public async Task<IActionResult> GetByIdEntertainments(string? EntertainmentId)
        {
            ResponseAPI<Entertainment> responseAPI = new ResponseAPI<Entertainment>();
            try
            {
                responseAPI.Data = await this.EntertainmentServices.GetByIdEntertainments(EntertainmentId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-insert-entertainment")]
        [HttpPost]
        public async Task<IActionResult> InserEntertainment(EntertainmentDto entertainment)
        {
            ResponseAPI<Entertainment> responseAPI = new ResponseAPI<Entertainment>();
            try
            {
                responseAPI.Data = await this.EntertainmentServices.InserEntertainment(entertainment);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Update by id for entertainment
        /// </summary>
        /// <param name="upEntertainment"></param>
        /// <returns></returns>
        [Route("get-update-entertainment")]
        [HttpPut]
        public async Task<IActionResult> UpdateEntertainment(EntertainmentDto upEntertainment)
        {
            ResponseAPI<Entertainment> responseAPI = new ResponseAPI<Entertainment>();
            try
            {
                responseAPI.Data = await this.EntertainmentServices.UpdateEntertainment(upEntertainment);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// delete list entertainment by id 
        /// </summary>
        /// <param name="EntertainmentId"></param>
        /// <returns></returns>
        [Route("get-delete-entertainment")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEntertainment([FromQuery]string[] EntertainmentId)
        {
            ResponseAPI<Entertainment> responseAPI = new ResponseAPI<Entertainment>();
            try
            {
                responseAPI.Data = await this.EntertainmentServices.DeleteEntertainment(EntertainmentId);
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
