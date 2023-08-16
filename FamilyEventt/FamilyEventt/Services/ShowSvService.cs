using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace FamilyEventt.Services
{
    public class ShowSvService : IShowServices
    {
        protected readonly FamilyEventContext context;
        public ShowSvService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteShowSvService(string[] showId)
        {
            try
            {
                var show = await this.context.ShowService
                    .Where(x => x.Status && showId.Contains(x.ShowId)).ToListAsync();               
                if (show != null && show.Count() >= 1)
                {
                    this.context.RemoveRange(show);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Not Found Name Show!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ShowServiceDto>> FilterShowServiceByManyOptions(string? name, string? singer, decimal? minPrice, decimal? maxPrice, bool? showServiceOption = true)
        {
            try 
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                var data = await this.context.ShowService
                    
                   .Where(x => minPrice == null || x.ShowPrice >= minPrice)
                   .Where(x => maxPrice == null || x.ShowPrice <= maxPrice)
                   .Where(x => x.Status == showServiceOption)
                   .Select(x => new ShowServiceDto
                   {
                       ShowId = x.ShowId,
                       ShowPrice = x.ShowPrice,
                       ShowServiceName = x.ShowServiceName,
                       Light = x.Light,
                       Sound = x.Sound,
                       Singer = x.Singer,
                       ShowDescription = x.ShowDescription,
                       ShowImage = x.ShowImage,
                       Status= x.Status,
                   }).ToListAsync();
                //data = data.Where(x => name == null || DataHelper.RemoveUnicode(x.ShowServiceName).ToLower().Contains(name)).ToList();
                data = data.Where(x => singer == null || DataHelper.RemoveUnicode(x.Singer).ToLower().Contains(singer)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Process went wrong");
            }
        }

        public async Task<List<ShowService>> GetAllShowServices()
        {
            try
            {
                return await this.context.ShowService.Where(x => x.Status)
                    .OrderBy(x => x.ShowServiceName).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<ShowService> GetByIdShowServices(string? showServiceId)
        {
            try { 
                    var data = await this.context.ShowService
                                         .Where(x => x.Status && (x.ShowId == showServiceId || x.ShowId == null))
                                         .Select(x => new ShowService
                                         {
                                                ShowId = x.ShowId,                                              
                                                ShowServiceName = x.ShowServiceName,
                                                ShowPrice = x.ShowPrice,
                                                Light = x.Light,
                                                Sound = x.Sound,
                                                Singer = x.Singer,
                                                ShowImage= x.ShowImage,
                                                ShowDescription = x.ShowDescription,
                                                Status = x.Status,
                                         }).FirstOrDefaultAsync();
                     return data;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> InsertShow(ShowServiceDto show)
        {
            try
            {
                var _show = new ShowService();
                _show.ShowId = "SId" + Guid.NewGuid().ToString().Substring(0, 20);
                
                _show.ShowServiceName = show.ShowServiceName;
                _show.ShowPrice = show.ShowPrice;
                _show.Light = show.Light;
                _show.Sound = show.Sound;
                _show.Singer = show.Singer;
                _show.ShowDescription = show.ShowDescription;
                _show.ShowImage = show.ShowImage;
                _show.Status = show.Status;
                await this.context.ShowService.AddAsync(_show);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ShowService>> SearchByNameShowService(string name)
        {
            try
            {
                return await this.context.ShowService.Where(x => x.Status && x.ShowServiceName.Contains(name)).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> UpdateShowService(ShowServiceDto upShow)
        {
            try
            {
                ShowService show = await this.context.ShowService.FirstOrDefaultAsync(x => x.Status && x.ShowId == upShow.ShowId);
                if (show != null)
                {
                    
                    show.ShowServiceName = upShow.ShowServiceName;
                    show.ShowPrice = show.ShowPrice;
                    show.Light = show.Light;
                    show.Sound = show.Sound;
                    show.Singer = show.Singer;
                    show.ShowDescription = show.ShowDescription;
                    show.ShowImage = show.ShowImage;
                    show.Status = show.Status;
                    await this.context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    throw new Exception("Not Found Show!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}