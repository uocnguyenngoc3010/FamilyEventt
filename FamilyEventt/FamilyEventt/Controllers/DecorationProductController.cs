using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DecorationProductController : ControllerBase
    {
        private IDecorationProduct _decorationProductService;
        public DecorationProductController(IDecorationProduct decorationProductService)
        {
            this._decorationProductService = decorationProductService;
        }
        [Route("get-all-decoration-product")]
        [HttpGet]
        public async Task<IActionResult> GetAllDecorationProduct()
        {
            ResponseAPI<List<DecorationProduct>> responseAPI = new ResponseAPI<List<DecorationProduct>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.GetAllDecorationProduct();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-decoration-product")]
        [HttpPost]
        public async Task<IActionResult> AddDecorationProduct(DecorationProductDto decorationProduct)
        {
            ResponseAPI<List<DecorationProduct>> responseAPI = new ResponseAPI<List<DecorationProduct>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.AddDecorationProduct(decorationProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
        [Route("get-by-id-decoration-product")]
        [HttpGet]
        public async Task<IActionResult> GetDecorationProductById(string? decorationId, string? productId)
        {
            ResponseAPI<List<DecorationProduct>> responseAPI = new ResponseAPI<List<DecorationProduct>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.GetDecorationProductById(decorationId,productId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("filter-decoration-product")]
        [HttpGet]
        public async Task<IActionResult> FilterDecorationProducts(string? decorationId, string? productId, decimal? minPrice, decimal? maxPrice, int? quantity, bool? quantityOption = true)
        {

            ResponseAPI<List<DecorationProductDto>> responseAPI = new ResponseAPI<List<DecorationProductDto>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.FilterDecorationProducts( decorationId, productId, minPrice, maxPrice, quantity, quantityOption);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-decoration-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateDecorationProduct(DecorationProductDto decorationProduct)
        {
            ResponseAPI<List<DecorationProduct>> responseAPI = new ResponseAPI<List<DecorationProduct>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.UpdateDecorationProduct(decorationProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(DecoProductUpdate decorationProduct)
        {
            ResponseAPI<List<DecorationProduct>> responseAPI = new ResponseAPI<List<DecorationProduct>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.UpdateProduct(decorationProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-decoration-product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDecorationProductById([FromQuery]List<string> decorationProductId)
        {
            ResponseAPI<List<DecorationProduct>> responseAPI = new ResponseAPI<List<DecorationProduct>>();
            try
            {
                responseAPI.Data = await this._decorationProductService.DeleteDecorationProductById(decorationProductId);
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
