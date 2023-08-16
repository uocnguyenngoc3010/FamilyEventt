using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RoomLocationController : ControllerBase
    {
        private IRoomLocation _roomService;

        public RoomLocationController(IRoomLocation roomService)
        {
            this._roomService = roomService;
        }

        [Route("get-all-room")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoom()
        {
            ResponseAPI<List<RoomLocation>> responseAPI = new ResponseAPI<List<RoomLocation>>();
            try
            {
                responseAPI.Data = await this._roomService.GetAllRoom();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }


        [Route("search-by-id-room")]
        [HttpGet]
        public async Task<IActionResult> GetRoomById(string Id)
        {
            ResponseAPI<RoomLocation> responseAPI = new ResponseAPI<RoomLocation>();
            try
            {
                responseAPI.Data = await this._roomService.GetRoomById(Id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-room")]
        [HttpPost]
        public async Task<IActionResult> InsertRoom(RoomLocationDto room)
        {
            ResponseAPI<List<RoomLocation>> responseAPI = new ResponseAPI<List<RoomLocation>>();
            try
            {
                responseAPI.Data = await this._roomService.InsertRoom(room);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("update-room")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(RoomLocationDto room)
        {
            ResponseAPI<List<RoomLocation>> responseAPI = new ResponseAPI<List<RoomLocation>>();
            try
            {
                responseAPI.Data = await this._roomService.UpdateRoom(room);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

       /// <summary>
       /// Delete room by ID
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [Route("delete-room")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(string Id)
        {
            ResponseAPI<List<RoomLocation>> responseAPI = new ResponseAPI<List<RoomLocation>>();
            try
            {
                responseAPI.Data = await this._roomService.DeleteRoom(Id);
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
