using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase {
        private IFood _foodService;
        public FoodController(IFood foodService)
        {
            this._foodService = foodService;
        }
        [Route("get-all-food")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.GetAllFoods();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-food-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetFoodById(string? id)
        {

            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.GetFoodById(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-food-by-food-type")]
        [HttpGet]
        public async Task<IActionResult> GetFoodByFoodType(string typeName)
        {

            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.SearchFoodsByFoodTypeName(typeName);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-name-food")]
        [HttpGet]
        public async Task<IActionResult> SearchByNameFood(string name)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.SearchByNameFoods(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("filter-food")]
        [HttpGet]
        public async Task<IActionResult> FilterFoodByManyOption(string? name, decimal? minPrice, decimal? maxPrice, bool? foodOption = true)
        {

            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.FilterFoodByManyOption(name, minPrice, maxPrice,foodOption );
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                //responseAPI.Data = false;
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-food")]
        [HttpPost]
        public async Task<IActionResult> InsertFood(FoodDto food)
        {
            ResponseAPI<List<FoodDto>> responseAPI = new ResponseAPI<List<FoodDto>>();
            try
            {
                responseAPI.Data = await this._foodService.InsertFood(food);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-food")]
        [HttpPut]
        public async Task<IActionResult> UpdateFood(FoodDto upFood)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.UpdateFood(upFood);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        
        [Route("delete-food")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFood([FromQuery]List<string> id)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._foodService.DeleteFood(id);
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
