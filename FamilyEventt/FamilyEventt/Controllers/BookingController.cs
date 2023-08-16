using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public IBooking Service;
        public BookingController(IBooking service)
        {
            this.Service = service;
        }
        /// <summary>
        /// View list information location
        /// </summary>
        /// <returns></returns>
        [Route("get-all-datetimeloacation")]
        [HttpGet]
        public async Task<IActionResult> GetAllDateTimeLocation()
        {
            ResponseAPI<List<DateTimeLocation>> responseAPI = new ResponseAPI<List<DateTimeLocation>>();
            try
            {
                responseAPI.Data = await this.Service.GetAllDateTimeLocation();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// View history booking eventbooker
        /// </summary>
        /// <param name="eventbooerID"></param>
        /// <returns></returns>
        [Route("get-datetimeloacation")]
        [HttpGet]
        public async Task<IActionResult> GetDateTimeLocationByEventBooker(string eventbooerID)
        {
            ResponseAPI<List<DateTimeLocation>> responseAPI = new ResponseAPI<List<DateTimeLocation>>();
            try
            {
                responseAPI.Data = await this.Service.GetDateTimeLocationByEventBooker(eventbooerID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// check room booked
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("check-used-room-by-date")]
        [HttpGet]
        public async Task<IActionResult> CheckUsedRoomByDay(DateTime date)
        {
            ResponseAPI<List<DateTimeLocation>> responseAPI = new ResponseAPI<List<DateTimeLocation>>();
            try
            {
                responseAPI.Data = await this.Service.CheckUsedRoomByDay(date);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Check room empty 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("check-empty-room-by-date")]
        [HttpGet]
        public async Task<IActionResult> CheckEmptyRoomByDay(DateTime date)
        {
            ResponseAPI<List<DateTimeLocation>> responseAPI = new ResponseAPI<List<DateTimeLocation>>();
            try
            {
                responseAPI.Data = await this.Service.CheckEmptyRoomByDay(date);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("booking")]
        [HttpPost]
        public async Task<IActionResult> BookingRoom(string eventID, string roomID, DateTime date)
        {
            ResponseAPI<List<DateTimeLocation>> responseAPI = new ResponseAPI<List<DateTimeLocation>>();
            try
            {
                responseAPI.Data = await this.Service.BookingRoom(eventID,roomID,date);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-booking")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(DateTimeLocationDto dto)
        {
            ResponseAPI<List<DateTimeLocation>> responseAPI = new ResponseAPI<List<DateTimeLocation>>();
            try
            {
                responseAPI.Data = await this.Service.DeleteBooking(dto);
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
