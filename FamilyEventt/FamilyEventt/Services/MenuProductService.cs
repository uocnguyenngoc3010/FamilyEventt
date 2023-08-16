using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class MenuProductService : IMenuProduct
    {
        protected readonly FamilyEventContext context;  
        public MenuProductService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteMenuProduct(string[] menuProductId)
        {
            try
            {
                var menuProducts = await this.context.MenuProduct
                    .Where(x => menuProductId.Contains(x.MenuId)).ToListAsync();
                if (menuProducts != null && menuProducts.Count() >= 1)
                {
                    this.context.RemoveRange(menuProducts);
                    this.context.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<MenuProductDto>> FilterMenuProductByManyOption(decimal? minPrice, decimal? maxPrice, int? qty, bool? quantityOption = true)
        {
            try
            {
                var data = await this.context.MenuProduct
                                 .Where(x => minPrice == null || x.Price >= minPrice)
                                 .Where(x => maxPrice == null || x.Price <= maxPrice)
                                 .Where(x => qty == null || (quantityOption == true ? x.Quatity >= qty : x.Quatity <= qty))
                                  .Select(x => new MenuProductDto
                                  {
                                      MenuId = x.MenuId,
                                      Product = x.Product,
                                      Quatity = x.Quatity,
                                      Price = x.Price,
                                      Type = x.Type,
                                      //Menu1 = new MenuDto
                                      //{
                                      //    MenuId = x.Menu1.MenuId,
                                      //    MenuName = x.Menu1.MenuName,
                                      //    Status = x.Menu1.Status,
                                      //    PriceTotal = x.Menu1.PriceTotal,
                                      //},


                                  })
                                 .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<MenuProduct>> GetAllMenuProduct()
        {
            try
            {
                var data = await this.context.MenuProduct.ToListAsync();
                //.Select(x => new MenuProductDto
                //{
                //    MenuId = x.MenuId,
                //    Product = x.Product,
                //    Quatity = x.Quatity,
                //    Price = x.Price,
                //    Type = x.Type,
                //    Menu1 = new MenuDto
                //    {
                //        MenuId = x.Menu1.MenuId,
                //        MenuName = x.Menu1.MenuName,
                //        Status = x.Menu1.Status,
                //        PriceTotal = x.Menu1.PriceTotal,

                //    },
                //    MenuNavigation = new FoodDto
                //    {
                //        FoodId = x.MenuNavigation.FoodId,
                //        FoodName = x.MenuNavigation.FoodName,
                //        Dish = x.MenuNavigation.Dish,
                //        FoodPrice = x.MenuNavigation.FoodPrice,
                //        //FoodQuantity = x.MenuNavigation.FoodQuantity,
                //        FoodDescription = x.MenuNavigation.FoodDescription,
                //        FoodIngredient = x.MenuNavigation.FoodIngredient,
                //        FoodOrigin = x.MenuNavigation.FoodOrigin,
                //        CookingRecipe = x.MenuNavigation.CookingRecipe,
                //        FoodImage = x.MenuNavigation.FoodImage,
                //        FoodTypeId = x.MenuNavigation.FoodTypeId,
                //        Status = x.MenuNavigation.Status,

                //    }

                //}).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<MenuProduct>> GetMenuProductById(string? menuProductId)
        {
            try
            {
                var data = await this.context.MenuProduct
                .Where(x => menuProductId == null || x.MenuId == menuProductId)
                .Select(x => new MenuProduct
                {
                    MenuId = x.MenuId,
                    Product = x.Product,
                    Quatity = x.Quatity,
                    Price = x.Price,
                    Type = x.Type,
                    ProductNavigation = new Food
                    {
                        FoodId = x.ProductNavigation.FoodId,
                        CookingRecipe = x.ProductNavigation.CookingRecipe,
                        Dish = x.ProductNavigation.Dish,
                        FoodDescription= x.ProductNavigation.FoodDescription,
                        FoodImage= x.ProductNavigation.FoodImage,
                        FoodIngredient = x.ProductNavigation.FoodIngredient,
                        FoodName= x.ProductNavigation.FoodName,
                        FoodOrigin= x.ProductNavigation.FoodOrigin,
                        FoodPrice= x.ProductNavigation.FoodPrice,
                        FoodTypeId= x.ProductNavigation.FoodTypeId,
                    }
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<bool> InsertMenuProduct(MenuProductDto menuProduct)
        {
            try
            {
                //var insertMenuProduct = await this.context.MenuProduct.Where(x => x.MenuId.Equals(menuProduct.MenuId))
                //    .FirstOrDefaultAsync();
                //if (insertMenuProduct != null)
                //    return false;

                MenuProduct newMenuProduct = new MenuProduct();
                newMenuProduct.MenuId = menuProduct.MenuId;
                //id product = time now 
                var data = await this.context.Food.Where(x=>x.FoodId.Equals(menuProduct.Product)).FirstOrDefaultAsync();
                newMenuProduct.Product = menuProduct.Product;
                newMenuProduct.Quatity = menuProduct.Quatity;
                newMenuProduct.Price = data.FoodPrice;
                newMenuProduct.Type = menuProduct.Type;


                await this.context.MenuProduct.AddAsync(newMenuProduct);
                this.context.SaveChanges();

                var menup= await this.context.MenuProduct.Where(x=>x.MenuId.Equals(newMenuProduct.MenuId)).ToListAsync();
                var me = await this.context.Menu.Where(x=>x.MenuId.Equals(newMenuProduct.MenuId)).FirstOrDefaultAsync();
                decimal tmp = 0;
                foreach (var item in menup)
                {
                    tmp += item.Price *item.Quatity;
                }
                me.PriceTotal = tmp;
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }
        public async Task<bool> UpdateMenuProduct(MenuProductDto updateMenuProduct)
        {
            try
            {
                var upMenuProduct = await this.context.MenuProduct
                                            .FirstAsync(x => x.MenuId == updateMenuProduct.MenuId);
                if (upMenuProduct != null)
                {
                    throw new ArgumentException("DecorationProductId not found");
                }
                upMenuProduct.MenuId = updateMenuProduct.MenuId;
                upMenuProduct.Product = updateMenuProduct.Product;
                upMenuProduct.Quatity = updateMenuProduct.Quatity;
                upMenuProduct.Price = updateMenuProduct.Price;
                upMenuProduct.Type = updateMenuProduct.Type;
                this.context.SaveChanges();

                var menup = await this.context.MenuProduct.Where(x => x.MenuId.Equals(upMenuProduct.MenuId)).ToListAsync();
                var me = await this.context.Menu.Where(x => x.MenuId.Equals(upMenuProduct.MenuId)).FirstOrDefaultAsync();
                decimal tmp = 0;
                foreach (var item in menup)
                {
                    tmp += item.Price * item.Quatity;
                }
                me.PriceTotal = tmp;
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("This MenuPorduct doesn't exist or Process went wrong");
            }
        }
    }
}
