using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "1")]
    public class EventBookerController : ControllerBase
    {
        private IEventBooker _eventBookerService;
        public EventBookerController(IEventBooker eventBookerService)
        {
            this._eventBookerService = eventBookerService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {

            ResponseAPI<List<EventBooker>> responseAPI = new ResponseAPI<List<EventBooker>>();
            try
            {
                responseAPI.Data = await this._eventBookerService.GetAllEventBookers();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [HttpGet("get-list-by-id-Eventbooker")]
        public async Task<IActionResult> GetByIdEventbooker(string? Id)
        {

            ResponseAPI<EventBooker> responseAPI = new ResponseAPI<EventBooker>();
            try
            {
                responseAPI.Data = await this._eventBookerService.GetByIdEventbooker(Id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpGet("get-by-phone")]
        public async Task<IActionResult> GetByPhoneEventbooker(string phone)
        {

            ResponseAPI<EventBooker> responseAPI = new ResponseAPI<EventBooker>();
            try
            {
                responseAPI.Data = await this._eventBookerService.GetEventBookerByPhone(phone);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-eventBooker")]
        [HttpPost]
        public async Task<IActionResult> InsertEventBooker(EventBookerDto eventBooker)
        {
            ResponseAPI<List<EventBooker>> responseAPI = new ResponseAPI<List<EventBooker>>();
            try
            {
                responseAPI.Data = await this._eventBookerService.InsertEventBooker(eventBooker);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-eventBooker-field")]
        [HttpPost]
        public async Task<IActionResult> InsertEventBookerfield(string Phone, string fullname, string addr, bool gender)
        {
            ResponseAPI<List<EventBooker>> responseAPI = new ResponseAPI<List<EventBooker>>();
            try
            {
                responseAPI.Data = await this._eventBookerService.InsertEventBookerfield(Phone,fullname,addr,gender);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-name-EventBooker")]
        [HttpGet]
        public async Task<IActionResult> SearchNameEventBooker(string name)
        {
            ResponseAPI<List<EventBooker>> responseAPI = new ResponseAPI<List<EventBooker>>();
            try
            {
                responseAPI.Data = await this._eventBookerService.SearchByNameEventBooker(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-event-booker")]
        [HttpPut]
        public async Task<IActionResult> UpdateEventBooker(EventBookerDto upEventBooker)
        {
            ResponseAPI<List<EventBooker>> responseAPI = new ResponseAPI<List<EventBooker>>();
            try
            {
                responseAPI.Data = await this._eventBookerService.UpdateEventBooker(upEventBooker);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("delete-event-booker")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEventBooker(string id)
        {
            ResponseAPI<List<EventBooker>> responseAPI = new ResponseAPI<List<EventBooker>>();
            try
            {
                responseAPI.Data = await this._eventBookerService.DeleteEventBooker(id);
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
