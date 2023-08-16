using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class FoodService : IFood
    {
        protected readonly FamilyEventContext context;
        public FoodService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteFood(List<string> id)
        {
            try
            {
                List<Food> foods = await this.context.Food
                    .Where(x => id.Contains(x.FoodId))
                    .ToListAsync();
                if (foods != null && foods.Count > 0)
                {

                    for (int i = 0; i < foods.Count; i++)
                    {
                        foods[i].Status = false;
                    }
                    await this.context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException("No Product found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<Food>> FilterFoodByManyOption(string? name, decimal? minPrice, decimal? maxPrice, bool? foodOption = true)
        {
            try
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                var data = await this.context.Food

                .Where(x => minPrice == null || x.FoodPrice >= minPrice)
                .Where(x => maxPrice == null || x.FoodPrice <= maxPrice)
                .Where(x => x.Status == foodOption)
                .Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    Dish = x.Dish,
                    FoodPrice = x.FoodPrice,
                    FoodDescription = x.FoodDescription,
                    FoodIngredient = x.FoodIngredient,
                    FoodOrigin = x.FoodOrigin,
                    CookingRecipe = x.CookingRecipe,
                    FoodImage = x.FoodImage,
                    Status = x.Status,
                    FoodType = new FoodType
                    {
                        FoodTypeId = x.FoodType.FoodTypeId,
                        FoodTypeName = x.FoodType.FoodTypeName,
                        FoodTypeDetail = x.FoodType.FoodTypeDetail
                    },
                })
                .ToListAsync();
                data = data.Where(x => name == null || DataHelper.RemoveUnicode(x.FoodName).ToLower().Contains(name)).ToList();
                return data;
            }
            catch
            {
                throw new ArgumentException("Process went wrong");
            }

        }

        public async Task<List<Food>> GetAllFoods()
        {
            try
            {

                var food = await this.context.Food.Where(x => x.Status).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    Dish = x.Dish,
                    FoodPrice = x.FoodPrice,
                    FoodDescription = x.FoodDescription,
                    FoodIngredient = x.FoodIngredient,
                    FoodOrigin = x.FoodOrigin,
                    CookingRecipe = x.CookingRecipe,
                    FoodImage = x.FoodImage,
                    FoodTypeId = x.FoodTypeId,
                    Status = x.Status,
                    FoodType = new FoodType
                    {
                        FoodTypeId = x.FoodType.FoodTypeId,
                        FoodTypeName = x.FoodType.FoodTypeName,
                        FoodTypeDetail = x.FoodType.FoodTypeDetail,
                    },
                }).ToListAsync();
                return food;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<Food> GetFoodById(string? id)
        {
            try
            {
                var data = await this.context.Food.Where(x => x.Status && x.FoodId == id).Select(x => new Food()
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    Dish = x.Dish,
                    FoodPrice = x.FoodPrice,
                    FoodDescription = x.FoodDescription,
                    FoodIngredient = x.FoodIngredient,
                    FoodOrigin = x.FoodOrigin,
                    CookingRecipe = x.CookingRecipe,
                    FoodImage = x.FoodImage,
                    FoodTypeId = x.FoodTypeId,
                    Status = x.Status,
                    FoodType = this.context.FoodType.Where(y => y.FoodTypeId == x.FoodTypeId).Select(y => new FoodType()
                    {
                        FoodTypeId = y.FoodTypeId,
                        FoodTypeName = y.FoodTypeName,
                        FoodTypeDetail = y.FoodTypeDetail,
                    }).FirstOrDefault(),
                }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("process wrong connect");
            }

        }

        public async Task<bool> InsertFood(FoodDto food)
        {
            Food _newFood = new Food();
            // "FID" + DateTime.Now.ToString("MMddyyHmmss"): use time for get Id
            //"FID" + DateTime.Now.ToString("MMddyyHmmss")
            _newFood.FoodId = "FID" + Guid.NewGuid().ToString().Substring(0, 20);
            _newFood.FoodName = food.FoodName;
            _newFood.Dish = food.Dish;
            _newFood.FoodPrice = food.FoodPrice;
            _newFood.FoodDescription = food.FoodDescription;
            _newFood.FoodIngredient = food.FoodIngredient;
            _newFood.FoodOrigin = food.FoodOrigin;
            _newFood.CookingRecipe = food.CookingRecipe;
            _newFood.FoodImage = food.FoodImage;
            _newFood.FoodTypeId = food.FoodTypeId;
            _newFood.Status = food.Status;
            await this.context.Food.AddAsync(_newFood);
             this.context.SaveChanges();
            return true;
        }

        public async Task<List<Food>> SearchByNameFoods(string name)
        {
            try
            {
                var data = await this.context.Food
                    .Where(x => x.Status && x.FoodName.Contains(name))
                    .ToListAsync();
                return data;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Food>> SearchFoodsByFoodTypeName(string typename)
        {
            try
            {
                var data = await this.context.Food
                    .Where(x => x.Status && x.FoodType.FoodTypeName.Equals(typename))
                    .ToListAsync();
                return data;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateFood(FoodDto upFood)
        {
            try
            {
                Food food = await this.context.Food.FirstOrDefaultAsync(x => x.FoodId == upFood.FoodId);
                if (food != null)
                {
                    food.FoodName = upFood.FoodName;
                    food.FoodPrice = upFood.FoodPrice;
                    food.FoodImage = upFood.FoodImage;
                    food.FoodDescription = upFood.FoodDescription;
                    food.FoodIngredient = upFood.FoodIngredient;
                    food.FoodOrigin = upFood.FoodOrigin;
                    food.CookingRecipe = upFood.CookingRecipe;
                    food.FoodImage = upFood.FoodImage;
                    food.FoodTypeId = upFood.FoodTypeId;
                    food.Status = upFood.Status;

                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Not Found Food!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
