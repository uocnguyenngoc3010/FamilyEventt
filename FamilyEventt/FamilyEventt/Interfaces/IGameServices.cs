using FamilyEventt.Dto;
using FamilyEventt.Models;
using FamilyEventt.Services;

namespace FamilyEventt.Interfaces
{
    public interface IGameServices
    {
        Task<List<GameServices>> GetAllGames();
        Task<GameServicesDto> GetByIdGame(string? gameId);
        Task<List<GameServices>> SearchByNameGames(string gameName);
        Task<bool> UpdateGame(GameServicesDto upGame);
        Task<bool> InsertGame(GameServicesDto game);
        Task<bool> DeleteGameById(string[] gameId);
    }
}
