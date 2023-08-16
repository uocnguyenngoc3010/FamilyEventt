using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        public IEventType EventTypeService;
        public EventTypeController(IEventType eventTypeService)
        {
            EventTypeService = eventTypeService;
        }

        [Route("get-all-event-type")]
        [HttpGet]
        public async Task<IActionResult> GetAllEventType()
        {
            ResponseAPI<List<EventType>> responseAPI = new ResponseAPI<List<EventType>>();
            try
            {
                responseAPI.Data = await this.EventTypeService.GetAllEvents();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-event-type")]
        [HttpPost]
        public async Task<IActionResult> InsertEventType(EventTypeDto eventDto)
        {
            ResponseAPI<List<EventType>> responseAPI = new ResponseAPI<List<EventType>>();
            try
            {
                responseAPI.Data = await this.EventTypeService.InsertEventType(eventDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("filter-event-type-by-many-option")]
        [HttpGet]
        public async Task<IActionResult> FilterEventTypeByManyOption(string? name, string? id)
        {
            ResponseAPI<List<EventType>> responseAPI = new ResponseAPI<List<EventType>>();
            try
            {
                responseAPI.Data = await this.EventTypeService.FilterEventTypeByManyOption(name, id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-eventtype-by-date")]
        [HttpGet]
        public async Task<IActionResult> GetEventTypeDate(DateTime date, string eventbooker)
        {
            ResponseAPI<List<EventType>> responseAPI = new ResponseAPI<List<EventType>>();
            try
            {
                responseAPI.Data = await this.EventTypeService.GetEventTypeByDate(date, eventbooker);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-event-type")]
        [HttpPut]
        public async Task<IActionResult> UpdateEventType(EventTypeDto eventDto)
        {
            ResponseAPI<List<EventType>> responseAPI = new ResponseAPI<List<EventType>>();
            try
            {
                responseAPI.Data = await this.EventTypeService.UpdateEventType(eventDto);
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
