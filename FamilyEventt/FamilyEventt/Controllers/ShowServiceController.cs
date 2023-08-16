using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ShowServiceController : ControllerBase
    {
        private IShowServices _showService;
        public ShowServiceController(IShowServices showService)
        {
            this._showService = showService;
        }
        [Route("get-all-show-service")]
        [HttpGet]
        public async Task <IActionResult> GetAllShowServices()
        {

            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            try
            {
                responseAPI.Data =await this._showService.GetAllShowServices();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-by-id-show")]
        [HttpGet]
        public async Task<IActionResult> GetByIdShowServices(string? id)
        {

            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            try
            {
                responseAPI.Data = await this._showService.GetByIdShowServices(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-show")]
        [HttpPost]
        public async Task <IActionResult> InsertShow(ShowServiceDto show)
        {
            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            try
            {
                responseAPI.Data =await this._showService.InsertShow(show);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-name-show")]
        [HttpGet]
        public async Task <IActionResult> SearchByNameShowService(string name)
        {
            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            try
            {
                responseAPI.Data =await this._showService.SearchByNameShowService(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("filter-show-service")]
        [HttpGet]
        public async Task<IActionResult> FilterShowServiceByManyOptions(string? name, string? singer, decimal? minPrice, decimal? maxPrice, bool? foodOption = true)
        {
            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            try
            {
                responseAPI.Data = await this._showService.FilterShowServiceByManyOptions( name, singer, minPrice, maxPrice, foodOption);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-show")]
        [HttpPut]
        //[Authorize(Roles = "admin")]
        public async Task <IActionResult> UpdateShowService(ShowServiceDto upShow)
        {
            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            try
            {
                responseAPI.Data =await this._showService.UpdateShowService(upShow);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-show")]
        [HttpDelete]
        public async Task <IActionResult> DeleteShowSvService([FromQuery]string[] id)
        {
            ResponseAPI<List<ShowService>> responseAPI = new ResponseAPI<List<ShowService>>();
            
            try
            {
                responseAPI.Data =await this._showService.DeleteShowSvService(id);
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
