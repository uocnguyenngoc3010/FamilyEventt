using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IFood
    {
        Task<Food> GetFoodById(string? id);
        Task<List<Food>> GetAllFoods();
        Task<List<Food>> FilterFoodByManyOption(string? name, decimal? minPrice, decimal? maxPrice, bool? foodOption = true);
        Task<List<Food>> SearchByNameFoods(string name);
        Task<bool> UpdateFood(FoodDto upFood);
        Task<bool> DeleteFood(List<string> id);
        Task<bool> InsertFood(FoodDto food);
        Task<List<Food>> SearchFoodsByFoodTypeName(string typename);
    }
}
