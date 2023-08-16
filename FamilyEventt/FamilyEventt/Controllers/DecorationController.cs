using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DecorationController : ControllerBase
    {
        IDecoration _decorationService;
        public DecorationController(IDecoration decorationService)
        {
            this._decorationService = decorationService;
        }
        [Route("get-all-decoration")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ResponseAPI<List<Decoration>> responseAPI = new ResponseAPI<List<Decoration>>();
            try
            {
                responseAPI.Data = await this._decorationService.GetAllDecoration();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-id-decoration")]
        [HttpGet]
        public async Task<IActionResult> GetDecorationById(string decorationId)
        {

            ResponseAPI<List<Decoration>> responseAPI = new ResponseAPI<List<Decoration>>();
            try
            {
                responseAPI.Data = await this._decorationService.GetDecorationById(decorationId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("filter-decoration")]
        [HttpGet]
        public async Task<IActionResult> FilterDecorationByManyOption(string? name, decimal? minPrice, decimal? maxPrice)
        {

            ResponseAPI<List<Decoration>> responseAPI = new ResponseAPI<List<Decoration>>();
            try
            {
                responseAPI.Data = await this._decorationService.FilterDecorationByManyOption(name, minPrice, maxPrice);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-decoration")]
        [HttpPost]
        public async Task<IActionResult> AddDecoration(DecorationDto decorationDto)
        {

            ResponseAPI<List<Decoration>> responseAPI = new ResponseAPI<List<Decoration>>();
            try
            {
                responseAPI.Data = await this._decorationService.AddDecoration(decorationDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-decoration")]
        [HttpPut]
        public async Task<IActionResult> UpdateDecoration( DecorationDto decoration)
        {

            ResponseAPI<List<Decoration>> responseAPI = new ResponseAPI<List<Decoration>>();
            try
            {
                responseAPI.Data = await this._decorationService.UpdateDecoration(decoration);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("delete-decoration")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDecoration([FromQuery] List<string> decorationId)
        {
            ResponseAPI<List<Decoration>> responseAPI = new ResponseAPI<List<Decoration>>();
            try
            {
                responseAPI.Data = await this._decorationService.DeleteDecorationById(decorationId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
