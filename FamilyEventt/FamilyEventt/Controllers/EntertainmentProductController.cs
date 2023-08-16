using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EntertainmentProductController : ControllerBase
    {
         IEntertainmentProduct _entertainmentProductServices;
        public EntertainmentProductController(IEntertainmentProduct entertainmentProductService)
        {
            this._entertainmentProductServices = entertainmentProductService;
        }
        [Route("get-all-entertainment-product")]
        [HttpGet]
        public async Task<IActionResult> GetAllEntertainmentProducts()
        {

            ResponseAPI<List<EntertainmentProduct>> responseAPI = new ResponseAPI<List<EntertainmentProduct>>();
            try
            {
                responseAPI.Data = await this._entertainmentProductServices.GetAllEntertainmentProducts();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// entertainmentProductId = ProductId. || 
        /// entertainmentId = EntertainmentId.
        /// </summary>
        /// <param name="entertainmentProductId"></param>
        /// <param name="entertainmentId"></param>
        /// <returns></returns>
        [Route("get-by-entertainment-product")]
        [HttpGet]
        public async Task<IActionResult> GetByIdEntertainmentProducts(string? entertainmentProductId, string? entertainmentId)
        {

            ResponseAPI<List<EntertainmentProduct>> responseAPI = new ResponseAPI<List<EntertainmentProduct>>();
            try
            {
                responseAPI.Data = await this._entertainmentProductServices.GetByIdEntertainmentProducts(entertainmentProductId,entertainmentId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entertainmentProduct"></param>
        /// <returns></returns>
        [Route("insert-entertainment-product")]
        [HttpPost]
        public async Task<IActionResult> InsertEntertainmentProduct(EntertainmentProductDto entertainmentProduct)
        {

            ResponseAPI<List<EntertainmentProduct>> responseAPI = new ResponseAPI<List<EntertainmentProduct>>();
            try
            {
                responseAPI.Data = await this._entertainmentProductServices.InsertEntertainmentProduct(entertainmentProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Enter ProductId you need to update
        /// </summary>
        /// <param name="upEntertainmentProduct"></param>
        /// <returns></returns>
        [Route("update-entertainment-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateEntertainmentProduct(EntertainmentProductDto upEntertainmentProduct)
        {

            ResponseAPI<EntertainmentProduct> responseAPI = new ResponseAPI<EntertainmentProduct>();
            try
            {
                responseAPI.Data = await this._entertainmentProductServices.UpdateEntertainmentProduct(upEntertainmentProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Delete entertainment product by id || 
        /// entertainmentProductId = ProductId
        /// </summary>
        /// <param name="entertainmentProductId"></param>
        /// <returns></returns>
        [Route("delete-entertainment-product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEntertainmentProduct([FromQuery]string[] entertainmentProductId)
        {

            ResponseAPI<EntertainmentProduct> responseAPI = new ResponseAPI<EntertainmentProduct>();
            try
            {
                responseAPI.Data = await this._entertainmentProductServices.DeleteEntertainmentProduct(entertainmentProductId);
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
