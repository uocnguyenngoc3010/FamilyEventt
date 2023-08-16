using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private IDrink _drinkService;
        public DrinkController(IDrink drinkService)
        {
            this._drinkService = drinkService;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllDrinks()
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._drinkService.GetAllDrinks();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-drink")]
        [HttpPost]
        public async Task<IActionResult>InsertDrink(FoodDto drink)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._drinkService.InsertDrink(drink);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("search-by-name-drink")]
        [HttpGet]
        public async Task <IActionResult>  SearchNameDrink(string name)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._drinkService.SearchByNameDrinks(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-by-id-drink")]
        [HttpGet]
        public async Task<IActionResult> GetByIdDrinks(string? drinkId)
        {
            ResponseAPI<Food> responseAPI = new ResponseAPI<Food>();
            try
            {
                responseAPI.Data = await this._drinkService.GetByIdDrinks(drinkId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-price-drink")]
        [HttpGet]
        public async Task<IActionResult> GetByPriceDrinks(decimal minSearchPrice, decimal maxSearchPrice)
        {
            ResponseAPI<Food> responseAPI = new ResponseAPI<Food>();
            try
            {
                responseAPI.Data = await this._drinkService.GetByPriceDrinks(minSearchPrice, maxSearchPrice);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Update drink with DrinkID
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("update-drink")]
        [HttpPut]
        public async Task <IActionResult>  UpdateDrink( FoodDto upDrink)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._drinkService.Update(upDrink);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-drink")]
        [HttpDelete]
        public async Task<IActionResult>  DeleteDrink(string drinkId)
        {
            ResponseAPI<List<Food>> responseAPI = new ResponseAPI<List<Food>>();
            try
            {
                responseAPI.Data = await this._drinkService.DeleteDrink(drinkId);
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
