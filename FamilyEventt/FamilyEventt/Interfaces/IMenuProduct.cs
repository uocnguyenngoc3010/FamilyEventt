using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IMenuProduct
    {
        Task<List<MenuProduct>> GetMenuProductById(string? menuProductId);
        Task<List<MenuProduct>> GetAllMenuProduct();
        Task<List<MenuProductDto>> FilterMenuProductByManyOption(decimal? minPrice, decimal? maxPrice, int? qty, bool? quantityOption = true);
        Task<bool> UpdateMenuProduct(MenuProductDto upMenuProduct);
        Task<bool> DeleteMenuProduct(string[] menuProductId);
        Task<bool> InsertMenuProduct(MenuProductDto menuProduct);
    }
}
