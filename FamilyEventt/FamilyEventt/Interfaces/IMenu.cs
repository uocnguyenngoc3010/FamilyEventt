using FamilyEventt.Dto;
using FamilyEventt.Dto.MenuDTOFE;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IMenu
    {
        Task<List<Menu>> GetAllMenu();
        Task<bool> DeleteMenu(List<string> menuId);
        Task<bool> UpdateMenu(MenuDto uptMenuDto);
        Task<Menu> InsertMenu(MenuDto newMenuDto);
        Task<List<MenuDto>> FilterMenuByManyOption(string? name, string? id, bool? menuOption = true);
        void Total(string id);
        Task<Menu> GetMenuByID(string id);
        Task<List<MenuProduct>> AddList(MenuFoodRequest dto);
    }
}
