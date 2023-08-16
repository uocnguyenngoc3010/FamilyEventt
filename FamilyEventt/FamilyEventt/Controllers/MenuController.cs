using FamilyEventt.Dto;
using FamilyEventt.Dto.MenuDTOFE;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenu _menuService;
        public MenuController(IMenu menuService)
        {
            this._menuService = menuService;
        }
        [Route("get-all-menu")]
        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {

            ResponseAPI<List<Menu>> responseAPI = new ResponseAPI<List<Menu>>();
            try
            {
                responseAPI.Data = await this._menuService.GetAllMenu();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-menu-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetMenuByID(string id)
        {

            ResponseAPI<Menu> responseAPI = new ResponseAPI<Menu>();
            try
            {
                responseAPI.Data = await this._menuService.GetMenuByID(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-filter-menu-by-option")]
        [HttpGet]
        public async Task<IActionResult> FilterMenuByManyOption(string? name, string? id, bool? menuOption = true)
        {

            ResponseAPI<List<Menu>> responseAPI = new ResponseAPI<List<Menu>>();
            try
            {
                responseAPI.Data = await this._menuService.FilterMenuByManyOption(name, id, menuOption);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-menu")]
        [HttpPost]
        public async Task<IActionResult> InsertMenu(MenuDto newMenuDto)
        {
            ResponseAPI<List<Menu>> responseAPI = new ResponseAPI<List<Menu>>();
            try
            {
                responseAPI.Data = await this._menuService.InsertMenu(newMenuDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-menu-list")]
        [HttpPost]
        public async Task<IActionResult> InsertMenuList(MenuFoodRequest dto)
        {
            ResponseAPI<List<MenuProduct>> responseAPI = new ResponseAPI<List<MenuProduct>>();
            try
            {
                responseAPI.Data = await this._menuService.AddList(dto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-menu")]
        [HttpPut]
        public async Task<IActionResult> UpdateMenu(MenuDto uptMenuDto)
        {
            ResponseAPI<List<Menu>> responseAPI = new ResponseAPI<List<Menu>>();
            try
            {
                responseAPI.Data = await this._menuService.UpdateMenu(uptMenuDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("remove-menu")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMenuProduct([FromQuery] List<string> menuProductId)
        {
            ResponseAPI<List<Menu>> responseAPI = new ResponseAPI<List<Menu>>();
            try
            {
                responseAPI.Data = await this._menuService.DeleteMenu(menuProductId);
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
