using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotification service;
        public NotificationController(INotification service)
        {
            this.service = service;
        }
        [Route("notification-event")]
        [HttpGet]
        public async Task<IActionResult> GetNotificationEvent(string eventid)
        {
            ResponseAPI<List<Notification>> responseAPI = new ResponseAPI<List<Notification>>();
            try
            {
                responseAPI.Data = await this.service.GetNotificationsByEvent(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// truyền vào id event
        /// type 0: tạo sự kiện thành công
        /// type 1: thanh toán thành công
        /// type 2: hủy đặt lịch thành công
        /// type 3: hoàn tiền thành công
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("create-notification")]
        [HttpPost]
        public async Task<IActionResult> CreateNotification(string eventID, int type)
        {
            ResponseAPI<Notification> responseAPI = new ResponseAPI<Notification>();
            try
            {
                responseAPI.Data = await this.service.CreateNotification(eventID, type);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// truyền vào id event
        /// type 0: sắp tới có sự kiện nào
        /// type 1: được mời tới sự kiện nào
        /// </summary>
        /// <param name="eventbooker"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("create-notification-family")]
        [HttpPost]
        public async Task<IActionResult> CreateNotificationFamily(string eventbooker, int type)
        {
            ResponseAPI<Notification> responseAPI = new ResponseAPI<Notification>();
            try
            {
                responseAPI.Data = await this.service.CreateNotificationForFamily(eventbooker, type);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
    }
}
