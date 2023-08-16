using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _productService;
        public ProductController(IProduct productService)
        {
            this._productService = productService;
        }
        [Route("get-all-product")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.GetAllProducts();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-name-product")]
        [HttpGet]
        public async Task<IActionResult> SearchNameProduct(string name)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.SearchByNameProducts(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-id-product")]
        [HttpGet]
        public async Task<IActionResult> SearchidProduct(string id)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.SearchByIDProducts(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-product")]
        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductDto iProduct)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.InsertProduct(iProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
        
        [Route("update-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto upProduct)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.UpdateProduct(upProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("filter-product")]
        [HttpGet]
        public async Task<IActionResult> FilterProduct(string? name, decimal? minPrice, decimal? maxPrice, string? supplier, int? qty, bool? qtyOption = true)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.FilterProductByManyOption(name, minPrice, maxPrice, supplier, qty, qtyOption);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] List<string> id)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this._productService.DeleteProduct(id);
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
