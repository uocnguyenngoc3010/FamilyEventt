    using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class FoodTypeService : IFoodType
    {
        protected readonly FamilyEventContext context;
        public FoodTypeService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool>DeleteFoodType(string[] foodId)
        {
            try
            {
                var foodType = await this.context.FoodType
                    .Where(x => foodId.Contains(x.FoodTypeId)).ToListAsync();
                if (foodType != null && foodType.Count() >= 1)
                {
                    this.context.RemoveRange(foodType);
                    this.context.SaveChanges();
                    return true;

                }
                else
                {
                    throw new Exception("Not Found Food Type!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<FoodType>> GetAllFoodTypes()
        {
            try
            {
                var data = await this.context.FoodType.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<FoodTypeDto> GetByIdFoodType(string? foodTypeId)
        {
            try
            {
                var data = await this.context.FoodType
                    .Where(x => foodTypeId == null || x.FoodTypeId == foodTypeId)
                    .Select(x => new FoodTypeDto
                    {
                        FoodTypeId = x.FoodTypeId,
                        FoodTypeName= x.FoodTypeName,
                        FoodTypeDetail= x.FoodTypeDetail,
                    }).FirstOrDefaultAsync();
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("Process went wrong"); 
            }
        }

        public async Task<bool>  InsertFoodType(FoodTypeDto foodType)
        {
            try
            {
                var _foodType = new FoodType();
                _foodType.FoodTypeId = "FTId" + Guid.NewGuid().ToString().Substring(0, 19);
                _foodType.FoodTypeName = foodType.FoodTypeName;
                _foodType.FoodTypeDetail= foodType.FoodTypeDetail;
                await this.context.FoodType.AddAsync(_foodType);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<FoodType>> SearchByNameFoodTypes(string FoodTypeNames)
        {
            try
            {
                var data = await this.context.FoodType.Where(x => x.FoodTypeName.Contains(FoodTypeNames)).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool>  UpdateFoodType(FoodTypeDto upFoodType)
        {
            try
            {
                FoodType foodType = await this.context.FoodType.FirstOrDefaultAsync(x => x.FoodTypeId == upFoodType.FoodTypeId);
                if (foodType != null)
                {
                   foodType.FoodTypeName = upFoodType.FoodTypeName;
                   foodType.FoodTypeDetail = upFoodType.FoodTypeDetail;
                   this.context.SaveChanges(); 
                   return true;

                }
                else
                {
                    throw new Exception("Not Found Food Type!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
