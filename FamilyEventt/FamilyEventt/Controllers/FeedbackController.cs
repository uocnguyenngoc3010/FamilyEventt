using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        public IFeedback Service;

        public FeedbackController(IFeedback service)
        {
            Service = service;
        }

        [Route("search-by-event")]
        [HttpGet]
        public async Task<IActionResult> GetScriptByEventID(string id)
        {
            ResponseAPI<List<FeedbackDto>> responseAPI = new ResponseAPI<List<FeedbackDto>>();
            try
            {
                responseAPI.Data = await this.Service.GetFeedbackByEvent(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-eventbooker")]
        [HttpGet]
        public async Task<IActionResult> GetFeedbackByEventBooker(string id)
        {
            ResponseAPI<List<FeedbackDto>> responseAPI = new ResponseAPI<List<FeedbackDto>>();
            try
            {
                responseAPI.Data = await this.Service.GetFeedbackByEventBooker(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-feedback")]
        [HttpPost]
        public async Task<IActionResult> InsertFeedback(FeedbackDto feedback)
        {
            ResponseAPI<List<FeedbackDto>> responseAPI = new ResponseAPI<List<FeedbackDto>>();
            try
            {
                responseAPI.Data = await this.Service.InsertFeedback(feedback);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("update-feedback")]
        [HttpPut]
        public async Task<IActionResult> UpdateFeedback(FeedbackDto feedback)
        {
            ResponseAPI<List<FeedbackDto>> responseAPI = new ResponseAPI<List<FeedbackDto>>();
            try
            {
                responseAPI.Data = await this.Service.UpdateFeedback(feedback);
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
