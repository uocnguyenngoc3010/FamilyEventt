using FamilyEventt.Dto;
using FamilyEventt.Dto.MenuDTOFE;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using GoogleApi.Entities.Search.Video.Common;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class MenuService : IMenu
    {
        protected readonly FamilyEventContext context;
        public MenuService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteMenu(List<string> menuId)
        {
            try
            {
                List<Menu> menus = await this.context.Menu
                    .Where(x => menuId.Contains(x.MenuId))
                    .ToListAsync();
                if (menus != null && menus.Count > 0)
                {

                    for (int i = 0; i < menus.Count; i++)
                    {
                        menus[i].Status = false;
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

        public async Task<List<MenuDto>> FilterMenuByManyOption(string? name, string? id,bool? menuOption = true)
        {
            try
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                var data = await this.context.Menu
                                 .Where(x => id == null || x.MenuId == id)
                                 
                                 .ToListAsync();
                data = data.Where(x => name == null ? true : DataHelper.RemoveUnicode(x.MenuName).ToLower().Contains(name)).ToList();
                var _menu = data.Select(x => new MenuDto
                {
                    MenuId = x.MenuId,
                    MenuName = x.MenuName,
                    PriceTotal = x.PriceTotal,
                    Status = x.Status = true,
                    
                }).ToList();

                return _menu;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<Menu>> GetAllMenu()
        {
            try
            {
                var data = await this.context.Menu
                    .Where(x => x.Status == true)
                    .OrderBy(x => x.MenuName)
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Success Went Wrong ");
            }

        }

        public async Task<Menu> GetMenuByID(string id)
        {
            try
            {
                var data = await this.context.Menu
                    .Where(x => x.Status == true && x.MenuId.Equals(id))
                    .OrderBy(x => x.MenuName)
                    .FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Success Went Wrong ");
            }

        }

        public void Total(string id)
        {
            try
            {
                decimal total =0;
                var data = this.context.Menu
                    .Where(x => x.Status == true && x.MenuId.Equals(id))
                    
                    .FirstOrDefault();

                var check = this.context.MenuProduct.Where(x=>x.MenuId.Equals(data.MenuId)).ToList();
                foreach(var item in check)
                {
                    total += item.Quatity * item.Price;
                }
                data.PriceTotal = total;
                this.context.Menu.Update(data);
                this.context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Success Went Wrong ");
            }

        }

        public async Task<Menu> InsertMenu(MenuDto newMenuDto)
        {
            try
            {
                var _menu = new Menu();
                _menu.MenuId = "MId" + Guid.NewGuid().ToString().Substring(0, 20);
                _menu.MenuName = newMenuDto.MenuName;
                _menu.PriceTotal= 0;
                _menu.Status = newMenuDto.Status == true;
                await this.context.Menu.AddAsync(_menu);
                this.context.SaveChanges();
                return _menu;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }

        }

        public async Task<bool> UpdateMenu(MenuDto uptMenuDto)
        {
            try
            {
                Menu menu = await this.context.Menu.FirstAsync(x => x.MenuId == uptMenuDto.MenuId);
                if (menu != null)
                {
                    menu.MenuId = uptMenuDto.MenuId;
                    menu.MenuName = uptMenuDto.MenuName;
                    menu.PriceTotal = uptMenuDto.PriceTotal;
                    menu.Status = uptMenuDto.Status;
                    this.context.SaveChanges();
                    return true;

                }
                else
                {
                    throw new ArgumentException("Product not found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<MenuProduct>> AddList(MenuFoodRequest dto)
        {
            try
            {
                Menu menu = new Menu();
                menu.Status = true;
                menu.MenuId = "MenuID"+Guid.NewGuid().ToString().Substring(0,18);
                menu.MenuName = dto.MenuName;
                menu.PriceTotal = 0;
                menu.TableQuantity= 0;
                await this.context.Menu.AddAsync(menu);
                await this.context.SaveChangesAsync();

                var li = new List<MenuProduct>();
                var menuproduct = new MenuProduct();
                foreach(var item in dto.food)
                {
                    menuproduct.MenuId = menu.MenuId;
                    menuproduct.Product = item.FoodId;
                    menuproduct.Price = item.FoodPrice;
                    menuproduct.Quatity = item.Quantity;
                    menuproduct.Type = true;
                    li.Add( menuproduct );
                    menuproduct = new MenuProduct();
                }
                foreach (var x in li)
                {
                    await this.context.MenuProduct.AddAsync(x);
                    await this.context.SaveChangesAsync();
                }

                var menup = await this.context.MenuProduct.Where(x => x.MenuId.Equals(menu.MenuId)).ToListAsync();
                var me = await this.context.Menu.Where(x => x.MenuId.Equals(menu.MenuId)).FirstOrDefaultAsync();
                decimal tmp = 0;
                foreach (var item in menup)
                {
                    tmp += item.Price * item.Quatity;
                }
                me.PriceTotal = tmp;
                await this.context.SaveChangesAsync();

                var data = await this.context.MenuProduct
                .Where(x => x.MenuId == menu.MenuId)
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
                        FoodDescription = x.ProductNavigation.FoodDescription,
                        FoodImage = x.ProductNavigation.FoodImage,
                        FoodIngredient = x.ProductNavigation.FoodIngredient,
                        FoodName = x.ProductNavigation.FoodName,
                        FoodOrigin = x.ProductNavigation.FoodOrigin,
                        FoodPrice = x.ProductNavigation.FoodPrice,
                        FoodTypeId = x.ProductNavigation.FoodTypeId,
                    }
                }).ToListAsync();
                if(data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
