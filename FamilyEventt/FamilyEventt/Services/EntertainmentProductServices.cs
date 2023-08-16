using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyEventt.Services
{
    public class EntertainmentProductServices : IEntertainmentProduct
    {
        protected readonly FamilyEventContext context;
        public EntertainmentProductServices(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteEntertainmentProduct(string[] entertainmentProductId)
        {
            try
            {
                var delEntertainment = await this.context.EntertainmentProduct
                                               .Where(x => entertainmentProductId.Contains(x.ProductId))
                                               .ToListAsync();
                if (delEntertainment != null && delEntertainment.Count() >= 1)
                {
                    this.context.RemoveRange(delEntertainment);
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

        public async Task<List<EntertainmentProduct>> GetAllEntertainmentProducts()
        {
            try
            {
                var data = await this.context.EntertainmentProduct
                    .Select(x=> new EntertainmentProduct
                    {
                        EntertainmentId = x.EntertainmentId,
                        ProductId = x.ProductId,
                        ShowId = x.ShowId,
                        GameId = x.GameId,
                        EntertainmentProductPrice = x.EntertainmentProductPrice,
                        Quantity = x.Quantity,
                        //Entertainment = new Entertainment
                        //{
                        //    EntertainmentId= x.EntertainmentId,
                        //    EntertainmentTotal = x.Entertainment.EntertainmentTotal,
                        //    Status = x.Entertainment.Status,
                        //},
                        Game = new GameServices
                        {
                            GameId = x.GameId,
                            GameDetails = x.Game.GameId,
                            GameName = x.Game.GameName,
                            GameImage= x.Game.GameImage,
                            //GameServicePrice= x.Game.GameServicePrice,
                            GameReward = x.Game.GameReward,
                        },
                        Show = new ShowService
                        {
                            ShowId = x.ShowId,
                            Light = x.Show.Light,
                            ShowDescription= x.Show.ShowDescription,
                            ShowImage = x.Show.ShowImage,
                            ShowServiceName= x.Show.ShowServiceName,
                            Singer = x.Show.Singer,
                            Sound= x.Show.Sound,
                        }
                    })
                    .ToListAsync();
                return data;
            }
             catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<EntertainmentProduct>> GetByIdEntertainmentProducts(string? entertainmentProductId, string? entertainmentId)
        {
            try
            {
                var data = await this.context.EntertainmentProduct
                .Where(x => entertainmentId == null || x.EntertainmentId == entertainmentId)
                .Where(x => entertainmentProductId == null || x.ProductId == entertainmentProductId)
                .Select(x => new EntertainmentProduct
                {
                    EntertainmentId = x.EntertainmentId,
                    ProductId = x.ProductId,
                    ShowId= x.ShowId,
                    GameId= x.GameId,
                    EntertainmentProductPrice = x.EntertainmentProductPrice,
                    Quantity = x.Quantity,

                    //Entertainment = new Entertainment
                    //{
                    //    EntertainmentId = x.Entertainment.EntertainmentId,
                    //    EntertainmentTotal = x.Entertainment.EntertainmentTotal,
                    //    Status = true

                    //},
                    Game = new GameServices
                    {
                        GameId = x.GameId,
                        GameDetails = x.Game.GameId,
                        GameName = x.Game.GameName,
                        GameImage = x.Game.GameImage,
                        //GameServicePrice= x.Game.GameServicePrice,
                        GameReward = x.Game.GameReward,
                    },
                    Show = new ShowService
                    {
                        ShowId = x.ShowId,
                        Light = x.Show.Light,
                        ShowDescription = x.Show.ShowDescription,
                        ShowImage = x.Show.ShowImage,
                        ShowServiceName = x.Show.ShowServiceName,
                        Singer = x.Show.Singer,
                        Sound = x.Show.Sound,
                    }

                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<bool> InsertEntertainmentProduct(EntertainmentProductDto entertainmentProduct)
        {
            try
            {
                EntertainmentProduct iEntertainmentProduct = new EntertainmentProduct();
                iEntertainmentProduct.EntertainmentId = entertainmentProduct.EntertainmentId;
                iEntertainmentProduct.ProductId = "EPId" + Guid.NewGuid().ToString().Substring(0,18);
                if(entertainmentProduct.ShowId!= null || entertainmentProduct.GameId ==null)
                {
                    iEntertainmentProduct.ShowId = entertainmentProduct.ShowId;
                    iEntertainmentProduct.GameId = null;
                }
                if(entertainmentProduct.ShowId == null || entertainmentProduct.GameId != null)
                {
                    iEntertainmentProduct.GameId = entertainmentProduct.GameId;
                    iEntertainmentProduct.ShowId = null;
                }
                iEntertainmentProduct.EntertainmentProductPrice = entertainmentProduct.EntertainmentProductPrice;
                iEntertainmentProduct.Quantity = entertainmentProduct.Quantity;
                this.context.EntertainmentProduct.Add(iEntertainmentProduct);
                this.context.SaveChanges();

                var etp = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(entertainmentProduct.EntertainmentId)).ToListAsync();
                int? count = 0;
                foreach (var item in etp)
                {
                    count += item.Quantity;
                }
                var ed = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(entertainmentProduct.EntertainmentId)).FirstOrDefaultAsync();
                if (ed != null)
                {
                    ed.EntertainmentTotal = (decimal)(count * 100000);
                }

                await this.context.SaveChangesAsync();

                //this.context.EventType.LoadAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false; 
            }
        }

        public async Task<bool> UpdateEntertainmentProduct(EntertainmentProductDto upEntertainmentProduct)
        {
            try
            {
                var up = await this.context.EntertainmentProduct
                    .Where(x => x.ProductId == upEntertainmentProduct.ProductId && (x.GameId.Equals(upEntertainmentProduct.GameId) ||x.ShowId.Equals(upEntertainmentProduct.ShowId)))
                    .FirstOrDefaultAsync();
                if (up == null)
                {
                    return false;
                }
                else
                {
                    //up.ProductId = upEntertainmentProduct.ProductId;
                    up.EntertainmentId = upEntertainmentProduct.EntertainmentId;
                    //up.EntertainmentId = upEntertainmentProduct.EntertainmentId;
                    up.ShowId= upEntertainmentProduct.ShowId;
                    up.GameId= upEntertainmentProduct.GameId;
                    up.EntertainmentProductPrice = upEntertainmentProduct.EntertainmentProductPrice;
                    up.Quantity= upEntertainmentProduct.Quantity;
                    this.context.EntertainmentProduct.Update(up);
                    await this.context.SaveChangesAsync();
                    var etp =await this.context.EntertainmentProduct.Where(x=>x.EntertainmentId.Equals(up.EntertainmentId)).ToListAsync();
                    int? count = 0;
                    foreach (var item in etp)
                    {
                        count += item.Quantity;
                    }
                    var ed = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(upEntertainmentProduct.EntertainmentId)).FirstOrDefaultAsync();
                    if (ed != null)
                    {
                        ed.EntertainmentTotal = (decimal)(count * 100000);
                    }

                    await this.context.SaveChangesAsync();
                    // this.context.EventType.LoadAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
