using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IShowServices
    {
        Task<List<ShowService>> GetAllShowServices();
        Task<ShowService> GetByIdShowServices(string? showServiceId);
        Task<List<ShowService>> SearchByNameShowService(string name);
        Task<bool> UpdateShowService(ShowServiceDto upShow);
        Task<bool> DeleteShowSvService(string[] showId);
        Task<bool> InsertShow(ShowServiceDto show);
        Task<List<ShowServiceDto>> FilterShowServiceByManyOptions(string? name, string singer, decimal? minPrice, decimal? maxPrice, bool? showServiceOption = true);
    }
}
