using FamilyEventt.Dto;
using FamilyEventt.ZaloPay;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ZaloPayController : ControllerBase
    {
        private readonly ZaloPayService _payService;
        public ZaloPayController(ZaloPayService payService)
        {
            _payService = payService;
        }
        // GET: api/<ZaloPayController>
        [HttpGet("{id}")]
        public async Task<IActionResult> CreateOrder(string id)
        {
            ResponseAPI<ZaloRespone> responseAPI = new ResponseAPI<ZaloRespone>();
            try
            {
                responseAPI.Data = await this._payService.CreateOrder(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        // GET api/<ZaloPayController>/5
        /*[HttpGet("{id}")]
        public async Task<IActionResult> Refund(string id)
        {
            ResponseAPI<ZaloPayRefund> responseAPI = new ResponseAPI<ZaloPayRefund>();
            try
            {
                responseAPI.Data = await this._payService.Refund(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }*/
    }
}
