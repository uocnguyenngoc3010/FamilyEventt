using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MenuProductController : ControllerBase
    {
        private IMenuProduct _menuProductService;
        private IMenu service;
        public MenuProductController(IMenuProduct menuProductService)
        {
            this._menuProductService = menuProductService;
        }
        [Route("get-all-menu-product")]
        [HttpGet]
        public async Task<IActionResult> GetAllMenuProduct()
        {

            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuProductService.GetAllMenuProduct();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-menu-product-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetMenuProductById(string? menuProductId)
        {

            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuProductService.GetMenuProductById(menuProductId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("filter-menu-product-by-many-option")]
        [HttpGet]
        public async Task<IActionResult> FilterMenuProductByManyOption(decimal? minPrice, decimal? maxPrice, int? qty, bool? quantityOption = true)
        {

            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuProductService.FilterMenuProductByManyOption(minPrice, maxPrice, qty, quantityOption);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-menu-product")]
        [HttpPost]
        public async Task<IActionResult> InsertMenuProduct(MenuProductDto menuProduct)
        {

            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuProductService.InsertMenuProduct(menuProduct);
                //service.Total(menuProduct.MenuId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-menu-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateMenuProduct(MenuProductDto upMenuProduct)
        {

            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuProductService.UpdateMenuProduct(upMenuProduct);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-menu-product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMenuProduct(string[] menuProductId)
        {

            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuProductService.DeleteMenuProduct( menuProductId);
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
