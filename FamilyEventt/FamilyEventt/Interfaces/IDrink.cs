using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IDrink
    {
        Task<List<Food>> GetAllDrinks();
        Task<List<Food>> SearchByNameDrinks(string name);
        Task<Food> GetByIdDrinks(string? id);
        Task<List<Food>> GetByPriceDrinks(decimal minSearchPrice, decimal maxSearchPrice);
        Task<bool> Update(FoodDto upFood);
        Task<bool> DeleteDrink(string drinkId);
        Task<bool> InsertDrink(FoodDto food);

    }
}
