using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private IFamily _familyService;
        public FamilyController(IFamily familyService)
        {
            this._familyService = familyService;
        }
        [Route("get-all-family")]
        [HttpGet]
        public async Task<IActionResult> GetAllFamily()
        {

            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.GetAllFamily();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-family-by-bookerid")]
        [HttpGet]
        public async Task<IActionResult> GetFamilyByEventBooker(string id)
        {

            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.GetFamilyByEventBooker(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-by-id-family-member")]
        [HttpGet]
        public async Task<IActionResult> GetFamilyMemberById(string id)
        {

            ResponseAPI<List<FamilyDto>> responseAPI = new ResponseAPI<List<FamilyDto>>();
            try
            {
                responseAPI.Data = await this._familyService.GetFamilyMemberById(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-name-family-member")]
        [HttpGet]
        public async Task<IActionResult> SearchByNameFamilyMember(string name)
        {

            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.SearchByNameFamilyMember(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("filter-family-by-many-option")]
        [HttpGet]
        public async Task<IActionResult> FilterFamilyByManyOption(string? name, string phone, string relation, bool? familyOption = true)
        {

            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.FilterFamilyByManyOption(name, phone, relation, familyOption);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-family-member")]
        [HttpPut]
        public async Task<IActionResult> UpdateFamily(FamilyDto upFamily)
        {

            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.UpdateFamily(upFamily);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("inser-family-member")]
        [HttpPost]
        public async Task<IActionResult> InsertFamilyMember(FamilyDto family)
        {

            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.InsertFamilyMember(family);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-family-member")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFamily([FromQuery]List<string> id)
        {
            ResponseAPI<List<Family>> responseAPI = new ResponseAPI<List<Family>>();
            try
            {
                responseAPI.Data = await this._familyService.DeleteFamily(id);
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
