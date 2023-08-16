using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FamilyEventt.Services
{
    public class GameSvService : IGameServices
    {
        protected readonly FamilyEventContext context;
        public GameSvService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task <bool> DeleteGameById(string[] gameId)
        {
            try
            {
                var game = await this.context.GameServices
                    .Where(x => gameId.Contains(x.GameId))
                    .ToListAsync();
                if (game != null && game.Count() >= 1)
                {
                    this.context.RemoveRange(game);
                    await this.context.SaveChangesAsync();

                }
                else
                {   
                    return false;
                    throw new Exception("Not Found Game!");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task <List<GameServices>> GetAllGames()
        {
            try
            {
                var data =await this.context.GameServices
                    .Where(x => x.Status)
                    .OrderBy(x=>x.GameName)
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<GameServicesDto> GetByIdGame(string? gameId)
        {
            try {
                    var data = await this.context.GameServices
                    .Where(x =>x.Status && (x.GameId == gameId || x.GameId == null))
                    .Select(x => new GameServicesDto
                    {
                        GameId = x.GameId,
                        GameName = x.GameName,
                        GameServicePrice = x.GameServicePrice,
                        GameDetails = x.GameDetails,
                        GameRules = x.GameRules,
                        GameReward = x.GameReward,
                        Supplies = x.Supplies,
                        GameImage = x.GameImage,
                        Status = x.Status,
                    }).FirstOrDefaultAsync();
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("Process went wrong");
            }
        }

        public async Task<bool>InsertGame(GameServicesDto game)
        {
            try
            {
                var _game = new GameServices();
                _game.GameId = "GId" + Guid.NewGuid().ToString().Substring(0, 20);
                _game.GameName = game.GameName;
                _game.GameServicePrice = game.GameServicePrice;
                _game.GameDetails = game.GameDetails;
                _game.GameRules = game.GameRules;
                _game.GameReward = game.GameReward;
                _game.Supplies = game.Supplies;
                _game.GameImage = game.GameImage;
                _game.Status = game.Status;
                await this.context.GameServices.AddAsync(_game);
                this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task <List<GameServices>> SearchByNameGames(string gameName)
        {
            try
            {
                var data = await this.context.GameServices
                    .Where(x => x.Status && x.GameName.Contains(gameName))
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task <bool> UpdateGame(GameServicesDto upGame)
        {
            try
            {
                GameServices game = await this.context.GameServices
                    .FirstOrDefaultAsync(x => x.GameId == upGame.GameId);
                if (game != null)
                {
                    game.GameName = upGame.GameName;
                    game.GameServicePrice = upGame.GameServicePrice;
                    game.GameDetails = upGame.GameDetails;
                    game.GameRules = upGame.GameRules;
                    game.GameReward = upGame.GameReward;
                    game.Supplies = upGame.Supplies;
                    game.GameImage = upGame.GameImage;
                    game.Status = upGame.Status;
                    this.context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Not Found Name Game!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
