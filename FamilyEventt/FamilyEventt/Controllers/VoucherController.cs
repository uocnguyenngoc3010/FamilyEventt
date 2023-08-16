using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private IVoucher service;
        public VoucherController(IVoucher service)
        {
            this.service = service;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllDrinks()
        {
            ResponseAPI<List<Voucher>> responseAPI = new ResponseAPI<List<Voucher>>();
            try
            {
                responseAPI.Data = await this.service.GetAllVoucher();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-voucher")]
        [HttpPost]
        public async Task<IActionResult> Insert(VoucherDto vc)
        {
            ResponseAPI<Voucher> responseAPI = new ResponseAPI<Voucher>();
            try
            {
                responseAPI.Data = await this.service.Insert(vc);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("add-voucher")]
        [HttpPost]
        public async Task<IActionResult> addVoucher(string vc, string eventid)
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.service.AddVoucher(eventid,vc);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-id-voucher")]
        [HttpGet]
        public async Task<IActionResult> searchByID(string id)
        {
            ResponseAPI<Voucher> responseAPI = new ResponseAPI<Voucher>();
            try
            {
                responseAPI.Data = await this.service.SearchByID(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-name-voucher")]
        [HttpGet]
        public async Task<IActionResult> SearchName(string name)
        {
            ResponseAPI<List<Voucher>> responseAPI = new ResponseAPI<List<Voucher>>();
            try
            {
                responseAPI.Data = await this.service.SearchByName(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-voucher")]
        [HttpPut]
        public async Task<IActionResult> Update(VoucherDto voucher)
        {
            ResponseAPI<Voucher> responseAPI = new ResponseAPI<Voucher>();
            try
            {
                responseAPI.Data = await this.service.Update(voucher);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpDelete("delete-voucher")]
        public async Task<IActionResult> Delete( string Id)
        {
            ResponseAPI<List<Voucher>> responseAPI = new ResponseAPI<List<Voucher>>();
            try
            {
                responseAPI.Data = await this.service.Delete(Id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [HttpDelete("disable-voucher")]
        public async Task<IActionResult> Disable()
        {
            ResponseAPI<List<Voucher>> responseAPI = new ResponseAPI<List<Voucher>>();
            try
            {
                responseAPI.Data = await this.service.Disable();
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
