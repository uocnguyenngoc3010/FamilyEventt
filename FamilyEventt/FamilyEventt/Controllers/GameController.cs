using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameServices _gameService;
        public GameController(IGameServices gameService)
        {
            this._gameService = gameService;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task <IActionResult> GetAllGames()
        {

            ResponseAPI<List<GameServices>> responseAPI = new ResponseAPI<List<GameServices>>();
            try
            {
                responseAPI.Data =await this._gameService.GetAllGames();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-by-id-game")]
        [HttpGet]
        public async Task<IActionResult> GetByIdGame(string? gameId)
        {

            ResponseAPI<GameServices> responseAPI = new ResponseAPI<GameServices>();
            try
            {
                responseAPI.Data = await this._gameService.GetByIdGame(gameId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-by-name-Game")]
        [HttpGet]
        public async Task <IActionResult> SearchByNameGames(string gameName)
        {
            ResponseAPI<List<GameServices>> responseAPI = new ResponseAPI<List<GameServices>>();
            try
            {
                responseAPI.Data =await this._gameService.SearchByNameGames(gameName);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("update-game")]
        [HttpPut]
        public async Task <IActionResult> UpdateGame( GameServicesDto upGame)
        {
            ResponseAPI<List<GameServices>> responseAPI = new ResponseAPI<List<GameServices>>();
            try
            {
                responseAPI.Data =await this._gameService.UpdateGame(upGame);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("insert-game")]
        [HttpPost]
        public async Task <IActionResult> InsertDrink( GameServicesDto game)
        {
            ResponseAPI<List<GameServices>> responseAPI = new ResponseAPI<List<GameServices>>();
            try
            {
                responseAPI.Data =await this._gameService.InsertGame(game);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }
        [Route("delete-game")]
        [HttpDelete]
        public async Task <IActionResult> DeleteGame([FromQuery]string[] id)
        {
            ResponseAPI<List<GameServices>> responseAPI = new ResponseAPI<List<GameServices>>();
            try
            {
                responseAPI.Data =await this._gameService.DeleteGameById(id);
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
