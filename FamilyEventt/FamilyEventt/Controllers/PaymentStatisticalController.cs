using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatisticalController : ControllerBase
    {
        public IPaymentStatistical Service;
        public PaymentStatisticalController(IPaymentStatistical service)
        {
            this.Service = service;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [Route("get-payment-statistial-all")]
        [HttpGet]
        public async Task<IActionResult> GetDataStatistical()

        {
            ResponseAPI<List<PaymentRespone>> responseAPI = new ResponseAPI<List<PaymentRespone>>();
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
        /// <summary>
        /// xem thống kê của event đó
        /// </summary>
        /// <param name="eventid"></param>
        /// <returns></returns>
        [Route("get-payment-statistial-eventID")]
        [HttpGet]
        public async Task<IActionResult> GetDataStatisticalEventID(string eventid)

        {
            ResponseAPI<List<PaymentRespone>> responseAPI = new ResponseAPI<List<PaymentRespone>>();
            try
            {
                responseAPI.Data = await this.Service.GetPaymentByEventID(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-payment-statistial-eventID-v2")]
        [HttpGet]
        public async Task<IActionResult> GetDataStatisticalEventIDv2(string eventid)

        {
            ResponseAPI<Statisticalv2dto> responseAPI = new ResponseAPI<Statisticalv2dto>();
            try
            {
                responseAPI.Data = await this.Service.GetPaymentByEventIDnew(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// xem thống kê các event của booker
        /// </summary>
        /// <param name="eventbookerid"></param>
        /// <returns></returns>
        [Route("get-payment-statistial-eventBookerID")]
        [HttpGet]
        public async Task<IActionResult> GetDataStatisticalEventBookerID(string eventbookerid)

        {
            ResponseAPI<List<PaymentRespone>> responseAPI = new ResponseAPI<List<PaymentRespone>>();
            try
            {
                responseAPI.Data = await this.Service.GetPaymentByEventBooker(eventbookerid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// type 0: xem thống kê doanh thu theo khoảng thời gian
        /// type 1: xem tổng doanh thu của toàn hệ thống, không tinh theo thời gian
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("get-payment-statistial-dashboard")]
        [HttpGet]
        public async Task<IActionResult> GetDataStatisticalFE(DateTime startDate, DateTime endDate, int type)

        {
            ResponseAPI<List<StatisticalRespone>> responseAPI = new ResponseAPI<List<StatisticalRespone>>();
            try
            {
                responseAPI.Data = await this.Service.GetResponeDataDate(startDate,endDate,type);
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
