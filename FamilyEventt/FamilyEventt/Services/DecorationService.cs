using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FamilyEventt.Services
{
    public class DecorationService : IDecoration
    {
        protected readonly FamilyEventContext context;
        public DecorationService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<Decoration> AddDecoration(DecorationDto decoration)
        {
            try
            {
                //var data = await this.context.Decoration.FirstAsync(x => x.DecorationId == decoration.DecorationId);
                //if (data == null)
                //{
                Decoration newDecoration = new Decoration();
                newDecoration.DecorationId = "DID" + Guid.NewGuid().ToString().Substring(0,20);
                newDecoration.DecorationImage = decoration.DecorationImage;
                newDecoration.DecorationPrice = decoration.DecorationPrice;
                newDecoration.DecorationName = decoration.DecorationName;
                this.context.Decoration.Add(newDecoration);
                await this.context.SaveChangesAsync();
                return newDecoration;
                //}
                // else throw new ArgumentException("This DecorationId has already existed");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }
        public async Task<bool> DeleteDecorationById(List<string> decorationId)
        {

            try
            {
                var decorations = await this.context.Decoration
                    .Where(x => decorationId.Contains(x.DecorationId)).ToListAsync();
                if (decorations != null && decorations.Count() >= 1)
                {
                    this.context.RemoveRange(decorations);
                    await this.context.SaveChangesAsync();
                }
                else return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public async Task<List<DecorationDto>> FilterDecorationByManyOption(string? name, decimal? minPrice, decimal? maxPrice)
        {
            try
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                var data = await this.context.Decoration
                    .Where(x => minPrice == null || x.DecorationPrice >= minPrice)
                    .Where(x => maxPrice == null || x.DecorationPrice <= maxPrice)
                    //.Where(x => name == null || x.DecorationName.Normalize().ToLower().Contains(name))
                    .Select(x => new DecorationDto
                    {
                        DecorationPrice = x.DecorationPrice,
                        DecorationId = x.DecorationId,
                        DecorationImage = x.DecorationImage,
                        DecorationName = x.DecorationName,
                    }).ToListAsync();
                data = data.Where(x => name == null || DataHelper.RemoveUnicode(x.DecorationName).ToLower().Contains(name)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process wrong");
            }
        }

        public async Task<List<DecorationDto>> GetAllDecoration()
        {
            try
            {
                var data = await this.context.Decoration.Select(x => new DecorationDto
                {
                    DecorationId = x.DecorationId,
                    DecorationImage = x.DecorationImage,
                    DecorationName = x.DecorationName,
                    DecorationPrice = x.DecorationPrice,
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Process went wrong");
            }
        }

        public async Task<DecorationDto> GetDecorationById(string id)
        {
            try
            {
                var data = await this.context.Decoration.FirstAsync(x => x.DecorationId == id);
                if (data != null)
                {
                    DecorationDto decorationDto = new DecorationDto();
                    decorationDto.DecorationId = data.DecorationId;
                    decorationDto.DecorationImage = data.DecorationImage;
                    decorationDto.DecorationName = data.DecorationName;
                    decorationDto.DecorationPrice = data.DecorationPrice;
                    return decorationDto;
                }
                else throw new ArgumentException("DecorationId not found");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Id not found or Process went wrong");
            }
        }

        public async Task<bool> UpdateDecoration(DecorationDto decorationDto)
        {
            try
            {
                var data = await this.context.Decoration.FirstAsync(x => x.DecorationId == decorationDto.DecorationId);
                if (data != null)
                {
                    data.DecorationPrice = decorationDto.DecorationPrice;
                    data.DecorationImage = decorationDto.DecorationImage;
                    data.DecorationName = decorationDto.DecorationName;
                    this.context.SaveChanges();
                    return true;
                }
                else throw new ArgumentException("DecorationId not found");
            }
            catch (Exception ex)
            {

                throw new ArgumentException("This Decoration not found or Process went wrong");
            }
        }
    }
}
