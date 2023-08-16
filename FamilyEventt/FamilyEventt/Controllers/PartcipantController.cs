using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartcipantController : ControllerBase
    {
        public IParticipant Participant;
        public PartcipantController(IParticipant participant)
        {
            Participant= participant;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllParticipant()
        {
            ResponseAPI<List<Participant>> responseAPI = new ResponseAPI<List<Participant>>();
            try
            {
                responseAPI.Data = await this.Participant.GetAllParticipant();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-participant")]
        [HttpPost]
        public async Task<IActionResult> InsertParticipant(ParticipantDto participant)
        {
            ResponseAPI<List<Participant>> responseAPI = new ResponseAPI<List<Participant>>();
            try
            {
                responseAPI.Data = await this.Participant.InsertParticipant(participant);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-event")]
        [HttpGet]
        public async Task<IActionResult> GetEventTypeByName(string ID)
        {
            ResponseAPI<List<Participant>> responseAPI = new ResponseAPI<List<Participant>>();
            try
            {
                responseAPI.Data = await this.Participant.GetParticipantsByEvent(ID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-Partcipant")]
        [HttpPut]
        public async Task<IActionResult> UpdateParticipant(ParticipantDto participant)
        {
            ResponseAPI<List<Participant>> responseAPI = new ResponseAPI<List<Participant>>();
            try
            {
                responseAPI.Data = await this.Participant.UpdateParticipant(participant);
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
