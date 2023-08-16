using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using GoogleApi.Entities.Search.Video.Common;

namespace FamilyEventt.Services
{
    public class DrinkService : IDrink
    {
        protected readonly FamilyEventContext context;
        //private List<Drink> drinkProducts;
        public DrinkService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteDrink(string drinkId)
        {
            try
            {
                var drink = await this.context.Food
                    .Where(x =>x.Status && x.FoodId.Equals(x.FoodId) &&x.FoodTypeId.Equals("FTIdd02f8f3b-4b82-4013-"))
                    .FirstOrDefaultAsync();
                if (drink != null )
                {
                    drink.Status = false;
                    await this.context.SaveChangesAsync();
                    
                }
                else
                {
                    throw new ArgumentException("No Drink Found");
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Food>> GetAllDrinks()
        {
               
            try
            {
                var data = await this.context.Food
                    .Where(x => x.Status == true && x.FoodTypeId.Equals("FTIdd02f8f3b-4b82-4013-"))
                    .OrderBy(x=>x.FoodName)
                    .ToListAsync();
                return data;
            }
            catch (Exception ex) {
                throw new Exception();
            }
           
        }

        public async Task<bool> InsertDrink(FoodDto food)
        {
            try
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
                _newFood.FoodTypeId = "FTIdd02f8f3b-4b82-4013-";
                _newFood.Status = food.Status;
                await this.context.Food.AddAsync(_newFood);
                this.context.SaveChanges();
               // await this.context.Drink.LoadAsync();
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public async Task<List<Food>> SearchByNameDrinks(string name)
        {
            try
            {
                var data = await this.context.Food
                    .Where(x => x.Status && x.FoodName.Contains(name) &&x.FoodTypeId.Equals("FTIdd02f8f3b-4b82-4013-"))
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Food> GetByIdDrinks(string? id)
        {
            try
            {
                var data = await this.context.Food.Where(x => x.Status && x.FoodId == id && x.FoodTypeId.Equals("FTIdd02f8f3b-4b82-4013-")).Select(x => new Food()
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


        public async Task<bool> Update(FoodDto upFood)
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

        public async Task <List<Food>> GetByPriceDrinks(decimal minSearchPrice, decimal maxSearchPrice)
        {
            try
            {
                return await context.Food.Where(d => d.FoodPrice >= minSearchPrice
                && d.FoodPrice <= maxSearchPrice
                && d.Status == true
                && d.FoodTypeId.Equals("FTIdd02f8f3b-4b82-4013-"))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
