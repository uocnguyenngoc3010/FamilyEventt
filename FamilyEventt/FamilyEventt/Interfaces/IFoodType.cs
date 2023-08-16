using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IFoodType
    {
        Task<List<FoodType>> GetAllFoodTypes();
        Task<FoodTypeDto> GetByIdFoodType(string? foodTypeId);
        Task<List<FoodType>> SearchByNameFoodTypes(string FoodTypeNames);
        Task<bool> UpdateFoodType(FoodTypeDto upFoodType);
        Task<bool> DeleteFoodType(string[] foodId);
        Task<bool> InsertFoodType(FoodTypeDto foodType);
    }
}
