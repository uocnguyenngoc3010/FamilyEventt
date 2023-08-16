using FamilyEventt.Dto;
using FamilyEventt.Dto.ResponeEventForExport;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using GoogleApi.Entities.Search.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FamilyEventt.Services
{
    public class EventService : IEvent
    {
        protected readonly FamilyEventContext context;

        public EventService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteEvent(string dltEventId)
        {
            try
            {
                var Event = await this.context.Event
                    .Where(x => x.EventId == dltEventId && x.Status).FirstOrDefaultAsync();
                if (Event == null)
                {
                    return false;
                }
                else
                {
                    Event.Status = false;
                    this.context.Event.Update(Event);
                    await this.context.SaveChangesAsync();
                    this.context.Event.LoadAsync();
                    return true;
                }
            }
            catch(Exception ex) 
            {
                return false;
            }
        }

        public async Task<List<Event>> GetAllEvents()
        {
            try
            {
                var Event = await this.context.Event
                    .Where(x => x.Status)
                    .Select(x => new Event
                    {
                        EventId = x.EventId,
                        ScriptId= x.ScriptId,
                        DecorationId = x.DecorationId,
                        EventTypeId    = x.EventTypeId,
                        MenuId = x.MenuId,
                        EntertainmentId = x.EntertainmentId,
                        EventBookerId = x.EventBookerId,
                        OrganizedPerson = x.OrganizedPerson,
                        StartDate = x.StartDate,
                        TotalPrice= x.TotalPrice,
                        EndDate= x.EndDate,
                        Status= x.Status,
                        Script = new Script
                        {
                            Id = x.Script.Id,
                            ScriptName = x.Script.ScriptName,
                            Status= x.Script.Status,
                            ScriptContent= x.Script.ScriptContent,
                        },
                        Decoration = new Decoration 
                        { 
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,
                            
                        },
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName,
                            EventTypeImage = x.EventType.EventTypeImage,
                            EventTypeDescription = x.EventType.EventTypeDescription,
                        },
                        Menu = new Menu
                        {
                            MenuId = x.Menu.MenuId,
                            MenuName = x.Menu.MenuName,
                            Status = x.Menu.Status,
                            PriceTotal = x.Menu.PriceTotal,
                        },
                        Entertainment  = new Entertainment
                        {
                            EntertainmentId = x.Entertainment.EntertainmentId,
                            Status = x.Entertainment.Status,
                            EntertainmentTotal = x.Entertainment.EntertainmentTotal
                            
                        },
                        EventBooker = new EventBooker 
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname,
                            Email = x.EventBooker.Email,
                            Phone = x.EventBooker.Phone,
                            Address= x.EventBooker.Address,
                            RegisterDate = x.EventBooker.RegisterDate,
                            Gender = x.EventBooker.Gender,
                            DateOfBirth = x.EventBooker.DateOfBirth,
                            Image = x.EventBooker.Image,
                            Status = x.EventBooker.Status,
                        },
                    })
                    //.Include(x=>x.EventBooker)
                    //.Include(x=>x.Menu)
                    //.Include(x=>x.Decoration)
                    //.Include(x=>x.Script)
                    //.Include(x=>x.Entertainment)
                    .ToListAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    this.context.Event.LoadAsync();
                    return Event;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Event>> GetEventByEventBookerID(string EventBookerID)
        {
            try
            {
                var Event = await this.context.Event
                    .Where(x => x.EventBookerId == EventBookerID)
                    .Select(x => new Event
                    {
                        EventId = x.EventId,
                        ScriptId = x.ScriptId,
                        DecorationId = x.DecorationId,
                        EventTypeId = x.EventTypeId,
                        MenuId = x.MenuId,
                        EntertainmentId = x.EntertainmentId,
                        EventBookerId = x.EventBookerId,
                        OrganizedPerson = x.OrganizedPerson,
                        StartDate = x.StartDate,
                        TotalPrice = x.TotalPrice,
                        EndDate = x.EndDate,
                        Status = x.Status,
                        Script = new Script
                        {
                            Id = x.Script.Id,
                            ScriptName = x.Script.ScriptName,
                            Status = x.Script.Status,
                            ScriptContent = x.Script.ScriptContent,
                        },
                        Decoration = new Decoration
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,

                        },
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName,
                            EventTypeImage = x.EventType.EventTypeImage,
                            EventTypeDescription = x.EventType.EventTypeDescription,
                        },
                        Menu = new Menu
                        {
                            MenuId = x.Menu.MenuId,
                            MenuName = x.Menu.MenuName,
                            Status = x.Menu.Status,
                            PriceTotal = x.Menu.PriceTotal,
                        },
                        Entertainment = new Entertainment
                        {
                            EntertainmentId = x.Entertainment.EntertainmentId,
                            Status = x.Entertainment.Status,
                            EntertainmentTotal = x.Entertainment.EntertainmentTotal

                        },
                        EventBooker = new EventBooker
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname,
                            Email = x.EventBooker.Email,
                            Phone = x.EventBooker.Phone,
                            Address = x.EventBooker.Address,
                            RegisterDate = x.EventBooker.RegisterDate,
                            Gender = x.EventBooker.Gender,
                            DateOfBirth = x.EventBooker.DateOfBirth,
                            Image = x.EventBooker.Image,
                            Status = x.EventBooker.Status,
                        },
                    })
                    //.Include( x => x.Verify )
                    //.Include(x => x.EventBooker)
                    //.Include(x => x.Menu)
                    //.Include(x => x.Decoration)
                    //.Include(x => x.Script)
                    //.Include(x => x.Entertainment)
                    .ToListAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    this.context.Event.LoadAsync();
                    return Event;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> InsertDataMobile(EventRequestDto dto)
        {
            try
            {
                AdminConfig ad = new AdminConfig();
                AdminConfigService sv = new AdminConfigService();
                ad = sv.GetConfig();
                DateTime min = Convert.ToDateTime(DateTime.Now);
                DateTime max = Convert.ToDateTime(dto.endDate);
                TimeSpan Time = max - min;
                int check = Time.Days;

                if (check < ad.registDateEvent)
                {
                    throw new Exception("sự kiện đăng ký phải cách "+ ad.registDateEvent +" ngày");
                }
                var ev = new Event();
                ev.EventId = "EVId" + Guid.NewGuid().ToString().Substring(0, 19);
                ev.Status = true;
                ev.StartDate = DateTime.Now; ev.EndDate = dto.endDate;


                var menu = new Menu();
                menu.MenuId = "MenuID" + Guid.NewGuid().ToString().Substring(0, 18);
                menu.MenuName = dto.MenuName;
                menu.Status = true;
                menu.PriceTotal = 0;
                menu.TableQuantity = dto.people / 10;
                await this.context.Menu.AddAsync(menu);
                await this.context.SaveChangesAsync();


                var li = new List<MenuProduct>();
                var menuproduct = new MenuProduct();
                foreach (var x in dto.foods)
                {
                    menuproduct.MenuId = menu.MenuId;
                    menuproduct.Product = x.foodID;
                    menuproduct.Price = x.Price;
                    menuproduct.Quatity = x.quantity;
                    li.Add(menuproduct);
                    menuproduct = new MenuProduct();
                }
                foreach (var x in li)
                {
                    await this.context.MenuProduct.AddAsync(x);
                    await this.context.SaveChangesAsync();
                }


                var deco = new Decoration();
                deco.DecorationId = "DecoID" + Guid.NewGuid().ToString().Substring(0, 18);

                if (dto.decorationName != null)
                {
                    deco.DecorationName = dto.decorationName;
                }
                else
                {
                    deco.DecorationName = "không đặt tên";
                }
                deco.DecorationPrice = 0;
                deco.DecorationImage = "null";
                await this.context.Decoration.AddAsync(deco);
                await this.context.SaveChangesAsync();

                var listde = new List<DecorationProduct>();
                var decorationproduct = new DecorationProduct();

                foreach (var x in dto.decorations)
                {
                    decorationproduct.DecorationId = deco.DecorationId;
                    decorationproduct.ProductId = x.productId;
                    decorationproduct.Price = x.Price;
                    decorationproduct.Quantity = x.quantity;
                    listde.Add(decorationproduct);
                    decorationproduct = new DecorationProduct();
                }
                foreach (var e in listde)
                {
                    await this.context.DecorationProduct.AddAsync(e);
                    await this.context.SaveChangesAsync();
                }

                var entertainment = new Entertainment();
                entertainment.EntertainmentId = "ETID" + Guid.NewGuid().ToString().Substring(0, 20);
                entertainment.Status = true;
                entertainment.EntertainmentTotal = 0;
                await this.context.Entertainment.AddAsync(entertainment);
                await this.context.SaveChangesAsync();

                var list = new List<EntertainmentProduct>();
                var ETProduct = new EntertainmentProduct();
                foreach (var x in dto.shows)
                {
                    ETProduct.EntertainmentId = entertainment.EntertainmentId;
                    ETProduct.ProductId = "tmpP" + Guid.NewGuid().ToString().Substring(0, 20);
                    ETProduct.ShowId = x.showId;
                    ETProduct.EntertainmentProductPrice = 100000;
                    ETProduct.Quantity = x.quantity;
                    list.Add(ETProduct);
                    ETProduct = new EntertainmentProduct();
                }
                foreach (var e in dto.games)
                {
                    ETProduct.EntertainmentId = entertainment.EntertainmentId;
                    ETProduct.ProductId = "tmpP" + Guid.NewGuid().ToString().Substring(0, 20);
                    ETProduct.EntertainmentProductPrice = 100000;
                    ETProduct.Quantity = e.quantity;
                    ETProduct.GameId = e.gameId;
                    list.Add(ETProduct);
                    ETProduct = new EntertainmentProduct();
                }
                foreach (var e in list)
                {
                    await this.context.EntertainmentProduct.AddAsync(e);
                    await this.context.SaveChangesAsync();
                }

                ev.EventTypeId = dto.EventTypeId;
                ev.EventBookerId = dto.eventbookerid;
                ev.DecorationId = deco.DecorationId;
                ev.EntertainmentId = entertainment.EntertainmentId;
                ev.ScriptId = dto.scriptId;
                if (dto.OrganizedPeople != null)
                {
                    ev.OrganizedPerson = dto.OrganizedPeople;
                }
                else
                {
                    ev.OrganizedPerson = "Null";
                }
                ev.TotalPrice = 0;
                ev.MenuId = menu.MenuId;

                // tính tiền
                decimal tmpAmount = 0;
                int count = 0;
                if (ev.MenuId != null)
                {
                    decimal menutotal = 0;
                    var menu1 = await this.context.MenuProduct.Where(x => x.MenuId.Equals(ev.MenuId)).ToListAsync();
                    foreach (var menuItem in menu1)
                    {
                        tmpAmount += menuItem.Price * menuItem.Quatity;
                        menutotal += menuItem.Price * menuItem.Quatity;
                    }
                    tmpAmount += tmpAmount * dto.people / 10;
                    var m = await this.context.Menu.Where(x => x.MenuId.Equals(ev.MenuId)).FirstOrDefaultAsync();
                    m.PriceTotal = menutotal;
                    this.context.SaveChanges();
                }
                if (ev.EntertainmentId != null)
                {
                    decimal total = 0;
                    var entertainment1 = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).ToListAsync();
                    foreach (var Item in entertainment1)
                    {
                        count++;
                    }
                    var d = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).FirstOrDefaultAsync();
                    d.EntertainmentTotal = count * 100000;
                    this.context.SaveChanges();
                }
                if (ev.DecorationId != null)
                {
                    decimal total = 0;
                    var decoration = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(ev.DecorationId)).ToListAsync();
                    foreach (var item in decoration)
                    {
                        tmpAmount += item.Price * item.Quantity;
                        total += item.Price * item.Quantity;
                    }
                    var db = await this.context.Decoration.Where(x => x.DecorationId.Equals(ev.DecorationId)).FirstOrDefaultAsync();
                    db.DecorationPrice = total;
                    this.context.SaveChanges();
                }
                ev.TotalPrice = tmpAmount + count * 100000;



                await this.context.Event.AddAsync(ev);
                await this.context.SaveChangesAsync();

                var Date = new DateTimeLocation();
                var checkroom = await this.context.DateTimeLocation.Where(x => x.RoomId.Equals(dto.room.roomId) && x.Date.Equals(dto.room.EventStart)).FirstOrDefaultAsync();
                if (checkroom != null)
                {
                    throw new Exception("Đã book ròi");
                }
                Date.Date = dto.room.EventStart;
                Date.RoomId = dto.room.roomId;
                Date.EventId = ev.EventId;
                DateTime min1 = Convert.ToDateTime(dto.room.EventStart);
                DateTime max1 = Convert.ToDateTime(dto.endDate);
                TimeSpan Time1 = max1 - min1;
                int check1 = Time.Days;

                if (check1 <= 0)
                {
                    throw new Exception("ngày diễn ra sự kiện phải trước ngày kết thúc");
                }
                Date.Status = 1;
                await this.context.DateTimeLocation.AddAsync(Date);
                await this.context.SaveChangesAsync();

                var verify = new VerifyService(context);
                if (verify.InsertVerifyCodeEvent1(ev.EventId))
                {
                    // vào dc đây là đúng code ròi đó
                }

                return ev.EventId;
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        public async Task<string> UpdateDataMobile(UpdateEventMobile dto)
        {
            try
            {
                AdminConfig ad = new AdminConfig();
                AdminConfigService sv = new AdminConfigService();
                ad = sv.GetConfig();
                var ev = await this.context.Event.Where(x => x.EventId.Equals(dto.evenid)).FirstOrDefaultAsync();
                ev.Status = true;
                ev.EndDate = dto.endDate;

                DateTime min = Convert.ToDateTime(DateTime.Now);
                DateTime max = Convert.ToDateTime(dto.endDate);
                TimeSpan Time = max - min;
                int check = Time.Days;

                if (check <= ad.updateDateEvent)
                {
                    throw new Exception("sự kiện đăng ký phải cập nhật trước "+ad.updateDateEvent+" ngày");
                }

                var menu = await this.context.Menu.Where(x => x.MenuId.Equals(ev.MenuId)).FirstOrDefaultAsync();
                menu.MenuName = dto.MenuName;
                menu.Status = true;
                menu.PriceTotal = 0;
                menu.TableQuantity = dto.people / 10;
                this.context.Menu.Update(menu);
                await this.context.SaveChangesAsync();

                var menup = await this.context.MenuProduct.Where(x=>x.MenuId.Equals(menu.MenuId)).ToListAsync();
                foreach(var x in menup)
                {
                    this.context.Remove(x);
                    await this.context.SaveChangesAsync();
                }
                var li = new List<MenuProduct>();
                var menuproduct = new MenuProduct();
                foreach (var x in dto.foods)
                {
                    menuproduct.MenuId = menu.MenuId;
                    menuproduct.Product = x.foodID;
                    menuproduct.Price = x.Price;
                    menuproduct.Quatity = x.quantity;
                    li.Add(menuproduct);
                    menuproduct = new MenuProduct();
                }
                foreach (var x in li)
                {
                    await this.context.MenuProduct.AddAsync(x);
                    await this.context.SaveChangesAsync();
                }


                var deco = await this.context.Decoration.Where(x => x.DecorationId.Equals(ev.DecorationId)).FirstOrDefaultAsync();
                if (dto.decorationName != null)
                {
                    deco.DecorationName = dto.decorationName;
                }
                else
                {
                    deco.DecorationName = "không đặt tên";
                }
                deco.DecorationPrice = 0;
                deco.DecorationImage = "null";
                this.context.Decoration.Update(deco);
                await this.context.SaveChangesAsync();


                var dep = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(deco.DecorationId)).ToListAsync();
                foreach(var x in dep)
                {
                    this.context.Remove(x);
                    await this.context.SaveChangesAsync();
                }
                var listde = new List<DecorationProduct>();
                var decorationproduct = new DecorationProduct();

                foreach (var x in dto.decorations)
                {
                    decorationproduct.DecorationId = deco.DecorationId;
                    decorationproduct.ProductId = x.productId;
                    decorationproduct.Price = x.Price;
                    decorationproduct.Quantity = x.quantity;
                    listde.Add(decorationproduct);
                    decorationproduct = new DecorationProduct();
                }
                foreach (var e in listde)
                {
                    await this.context.DecorationProduct.AddAsync(e);
                    await this.context.SaveChangesAsync();
                }

                var entertainment = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).FirstOrDefaultAsync();
                entertainment.Status = true;
                entertainment.EntertainmentTotal = 0;
                this.context.Entertainment.Update(entertainment);
                await this.context.SaveChangesAsync();

                var etli = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(entertainment.EntertainmentId)).ToListAsync();
                foreach(var x in etli)
                {
                    this.context.Remove(x);
                    await this.context.SaveChangesAsync();
                }
                var list = new List<EntertainmentProduct>();
                var ETProduct = new EntertainmentProduct();
                foreach (var x in dto.shows)
                {
                    ETProduct.EntertainmentId = entertainment.EntertainmentId;
                    ETProduct.ProductId = "tmpP" + Guid.NewGuid().ToString().Substring(0, 20);
                    ETProduct.ShowId = x.showId;
                    ETProduct.EntertainmentProductPrice = 100000;
                    ETProduct.Quantity = x.quantity;
                    list.Add(ETProduct);
                    ETProduct = new EntertainmentProduct();
                }
                foreach (var e in dto.games)
                {
                    ETProduct.EntertainmentId = entertainment.EntertainmentId;
                    ETProduct.ProductId = "tmpP" + Guid.NewGuid().ToString().Substring(0, 20);
                    //ETProduct.ShowId = x.showId;
                    ETProduct.EntertainmentProductPrice = 100000;
                    ETProduct.Quantity = e.quantity;
                    ETProduct.GameId = e.gameId;
                    list.Add(ETProduct);
                    ETProduct = new EntertainmentProduct();
                }
                foreach (var e in list)
                {
                    await this.context.EntertainmentProduct.AddAsync(e);
                    await this.context.SaveChangesAsync();
                }

                ev.EventTypeId = dto.EventTypeId;
                ev.DecorationId = deco.DecorationId;
                ev.EntertainmentId = entertainment.EntertainmentId;
                ev.ScriptId = dto.scriptId;
                if (dto.OrganizedPeople != null)
                {
                    ev.OrganizedPerson = dto.OrganizedPeople;
                }
                else
                {
                    ev.OrganizedPerson = "Null";
                }
                ev.TotalPrice = 0;
                ev.MenuId = menu.MenuId;

                // tính tiền
                decimal tmpAmount = 0;
                int count = 0;
                if (ev.MenuId != null)
                {
                    decimal menutotal = 0;
                    var menu1 = await this.context.MenuProduct.Where(x => x.MenuId.Equals(ev.MenuId)).ToListAsync();
                    foreach (var menuItem in menu1)
                    {
                        tmpAmount += menuItem.Price * menuItem.Quatity;
                        menutotal += menuItem.Price * menuItem.Quatity;
                    }
                    tmpAmount += tmpAmount * dto.people / 10;
                    var m = await this.context.Menu.Where(x => x.MenuId.Equals(ev.MenuId)).FirstOrDefaultAsync();
                    m.PriceTotal = menutotal;
                    this.context.SaveChanges();
                }
                if (ev.EntertainmentId != null)
                {
                    decimal total = 0;
                    var entertainment1 = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).ToListAsync();
                    foreach (var Item in entertainment1)
                    {
                        count++;
                    }
                    var d = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).FirstOrDefaultAsync();
                    d.EntertainmentTotal = count * 100000;
                    this.context.SaveChanges();
                }
                if (ev.DecorationId != null)
                {
                    decimal total = 0;
                    var decoration = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(ev.DecorationId)).ToListAsync();
                    foreach (var item in decoration)
                    {
                        tmpAmount += item.Price * item.Quantity;
                        total += item.Price * item.Quantity;
                    }
                    var db = await this.context.Decoration.Where(x => x.DecorationId.Equals(ev.DecorationId)).FirstOrDefaultAsync();
                    db.DecorationPrice = total;
                    this.context.SaveChanges();
                }
                ev.TotalPrice = tmpAmount + count * 100000;



                this.context.Event.Update(ev);
                await this.context.SaveChangesAsync();

                var dtl = await this.context.DateTimeLocation.Where(x=>x.EventId.Equals(ev.EventId)).ToListAsync();
                foreach (var item in dtl)
                {
                    this.context.Remove(item);
                    await this.context.SaveChangesAsync();
                }
                var Date = new DateTimeLocation();
                var checkroom = await this.context.DateTimeLocation.Where(x => x.RoomId.Equals(dto.room.roomId) && x.Date.Equals(dto.room.EventStart)).FirstOrDefaultAsync();
                if (checkroom != null)
                {
                    throw new Exception("Đã book ròi");
                }
                Date.Date = dto.room.EventStart;
                Date.RoomId = dto.room.roomId;
                Date.EventId = ev.EventId;
                DateTime min1 = Convert.ToDateTime(dto.room.EventStart);
                DateTime max1 = Convert.ToDateTime(dto.endDate);
                TimeSpan Time1 = max1 - min1;
                int check1 = Time.Days;

                if (check1 <= 0)
                {
                    throw new Exception("ngày diễn ra sự kiện phải trước ngày kết thúc");
                }
                Date.Status = 1;
                await this.context.DateTimeLocation.AddAsync(Date);
                await this.context.SaveChangesAsync();


                return ev.EventId;
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        public async Task<bool> InsertEvent(EventDto newEvent)
        {
            try
            {
                //check ngày
                DateTime min = Convert.ToDateTime(DateTime.Now);
                DateTime max = Convert.ToDateTime(newEvent.EndDate);
                TimeSpan Time = max - min;
                int check = Time.Days;

                if(check < 14)
                {
                    return false;
                }
                var _event = new Event();
                _event.EventId= "EVId" + Guid.NewGuid().ToString().Substring(0,19);

                //Event _event = new Event();


                _event.ScriptId = newEvent.ScriptId;
                _event.Status = newEvent.Status;
                _event.DecorationId = newEvent.DecorationId;
                _event.EntertainmentId = newEvent.EntertainmentId;
                _event.EventBookerId = newEvent.EventBookerId;
                _event.MenuId = newEvent.MenuId;
                _event.EventTypeId = newEvent.EventTypeId;
                _event.StartDate = DateTime.Now;
                _event.EndDate = newEvent.EndDate;
                _event.OrganizedPerson = newEvent.OrganizedPerson;
                //update caculate total price
                decimal tmpAmount =0;
                int count = 0;
                if(newEvent.MenuId!= null)
                {
                    decimal menutotal = 0;
                    var menu = await this.context.MenuProduct.Where(x => x.MenuId.Equals(newEvent.MenuId)).ToListAsync();
                    foreach (var menuItem in menu)
                    {
                        tmpAmount += menuItem.Price * menuItem.Quatity;
                        menutotal = tmpAmount;
                    }
                    var m = await this.context.Menu.Where(x => x.MenuId.Equals(newEvent.MenuId)).FirstOrDefaultAsync();
                    m.PriceTotal = menutotal;
                    this.context.SaveChanges();
                }
                if (newEvent.EntertainmentId != null)
                {
                    decimal total = 0;
                    var entertainment = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(newEvent.EntertainmentId)).ToListAsync();
                    foreach (var Item in entertainment)
                    {
                        count++;
                    }
                    var d = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(newEvent.EntertainmentId)).FirstOrDefaultAsync();
                    d.EntertainmentTotal = count * 100000;
                    this.context.SaveChanges();
                }
                if (newEvent.DecorationId != null)
                {
                    decimal total = 0;
                    var decoration = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(newEvent.DecorationId)).ToListAsync();
                    foreach (var item in decoration)
                    {
                        tmpAmount += item.Price * item.Quantity;
                        total += item.Price * item.Quantity;
                    }
                    var db = await this.context.Decoration.Where(x => x.DecorationId.Equals(newEvent.DecorationId)).FirstOrDefaultAsync();
                    db.DecorationPrice = total;
                    this.context.SaveChanges();
                }
                _event.TotalPrice = tmpAmount + count*100000;

                
                this.context.Event.Add(_event);
                await this.context.SaveChangesAsync();
                this.context.Event.Load();

                // insert data verify 
                var verify = new VerifyService(context);
                if (verify.InsertVerifyCodeEvent1(_event.EventId))
                {
                    // vào dc đây là đúng code ròi đó
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateEvent(EventDto uptEventDto)
        {
            try
            {
                var Event = await this.context.Event
                    .Where(x => x.EventId == uptEventDto.EventId && x.Status).FirstOrDefaultAsync();
                if (Event == null)
                {
                    return false;
                }
                else
                {
                    Event.ScriptId = uptEventDto.ScriptId;
                    Event.Status = uptEventDto.Status;
                    Event.DecorationId = uptEventDto.DecorationId;
                    Event.EntertainmentId = uptEventDto.EntertainmentId;
                    Event.EventBookerId = uptEventDto.EventBookerId;
                    Event.MenuId = uptEventDto.MenuId;
                    Event.EventTypeId = uptEventDto.EventTypeId;
                    Event.StartDate = uptEventDto.StartDate;
                    Event.EndDate = uptEventDto.EndDate;
                    Event.OrganizedPerson = uptEventDto.OrganizedPerson;

                    decimal tmpAmount = 0;
                    int count = 0;
                    if (uptEventDto.MenuId != null)
                    {
                        decimal menutotal = 0;
                        var menu = await this.context.MenuProduct.Where(x => x.MenuId.Equals(uptEventDto.MenuId)).ToListAsync();
                        foreach (var menuItem in menu)
                        {
                            tmpAmount += menuItem.Price * menuItem.Quatity;
                            menutotal = tmpAmount;
                        }
                        var m = await this.context.Menu.Where(x => x.MenuId.Equals(uptEventDto.MenuId)).FirstOrDefaultAsync();
                        m.PriceTotal = menutotal;
                        this.context.SaveChanges();
                    }
                    if (uptEventDto.EntertainmentId != null)
                    {
                        decimal total = 0;
                        var entertainment = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(uptEventDto.EntertainmentId)).ToListAsync();
                        foreach (var Item in entertainment)
                        {
                            count++;
                        }
                        var d = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(uptEventDto.EntertainmentId)).FirstOrDefaultAsync();
                        d.EntertainmentTotal = count * 100000;
                        this.context.SaveChanges();
                    }
                    if (uptEventDto.DecorationId != null)
                    {
                        decimal total = 0;
                        var decoration = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(uptEventDto.DecorationId)).ToListAsync();
                        foreach (var item in decoration)
                        {
                            tmpAmount += item.Price * item.Quantity;
                            total += item.Price * item.Quantity;
                        }
                        var db = await this.context.Decoration.Where(x => x.DecorationId.Equals(uptEventDto.DecorationId)).FirstOrDefaultAsync();
                        db.DecorationPrice = total;
                        this.context.SaveChanges();
                    }
                    Event.TotalPrice = tmpAmount + count * 100000;

                    this.context.Event.Update(Event);
                    await this.context.SaveChangesAsync();
                    this.context.Event.Load();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateEventAll()
        {
            try
            {
                
                var Event = await this.context.Event
                    .Where(x =>  x.Status).ToListAsync();
                if (Event == null)
                {
                    return false;
                }
                else
                {
                    foreach(var ev in Event)
                    {
                        decimal tmpAmount = 0;
                        int count = 0;
                        if (ev.MenuId != null)
                        {
                            decimal menutotal = 0;
                            var menu = await this.context.MenuProduct.Where(x => x.MenuId.Equals(ev.MenuId)).ToListAsync();
                            foreach (var menuItem in menu)
                            {
                                tmpAmount += menuItem.Price * menuItem.Quatity;
                                menutotal = tmpAmount;
                            }
                            var m = await this.context.Menu.Where(x => x.MenuId.Equals(ev.MenuId)).FirstOrDefaultAsync();
                            m.PriceTotal = menutotal;
                            this.context.SaveChanges();
                        }
                        if (ev.EntertainmentId != null)
                        {
                            decimal total = 0;
                            var entertainment = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).ToListAsync();
                            foreach (var Item in entertainment)
                            {
                                count++;
                            }
                            var d = await this.context.Entertainment.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).FirstOrDefaultAsync();
                            d.EntertainmentTotal = count * 100000;
                            this.context.SaveChanges();
                        }
                        if (ev.DecorationId != null)
                        {
                            decimal total = 0;
                            var decoration = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(ev.DecorationId)).ToListAsync();
                            foreach (var item in decoration)
                            {
                                tmpAmount += item.Price * item.Quantity;
                                total += item.Price * item.Quantity;
                            }
                            var db = await this.context.Decoration.Where(x => x.DecorationId.Equals(ev.DecorationId)).FirstOrDefaultAsync();
                            db.DecorationPrice = total;
                            this.context.SaveChanges();
                        }
                        ev.TotalPrice = tmpAmount + count * 100000;

                        this.context.Event.Update(ev);
                        await this.context.SaveChangesAsync();
                        this.context.Event.Load();
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Event> GetEventByID(string id)
        {
            try
            {
                var Event = await this.context.Event
                    .Where(x => x.EventId.Equals(id) && x.Status)
                    .Select(x => new Event
                    {
                        EventId = x.EventId,
                        ScriptId = x.ScriptId,
                        DecorationId = x.DecorationId,
                        EventTypeId = x.EventTypeId,
                        MenuId = x.MenuId,
                        EntertainmentId = x.EntertainmentId,
                        EventBookerId = x.EventBookerId,
                        OrganizedPerson = x.OrganizedPerson,
                        StartDate = x.StartDate,
                        TotalPrice = x.TotalPrice,
                        EndDate = x.EndDate,
                        Status = x.Status,
                        Script = new Script
                        {
                            Id = x.Script.Id,
                            ScriptName = x.Script.ScriptName,
                            Status = x.Script.Status,
                            ScriptContent = x.Script.ScriptContent,
                        },
                        Decoration = new Decoration
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,
                            DecorationProduct= x.Decoration.DecorationProduct,
                        },
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName,
                            EventTypeImage = x.EventType.EventTypeImage,
                            EventTypeDescription = x.EventType.EventTypeDescription,
                        },
                        Menu = new Menu
                        {
                            MenuId = x.Menu.MenuId,
                            MenuName = x.Menu.MenuName,
                            Status = x.Menu.Status,
                            PriceTotal = x.Menu.PriceTotal,
                            TableQuantity= x.Menu.TableQuantity,
                            MenuProduct= x.Menu.MenuProduct,
                        },
                        Entertainment = new Entertainment
                        {
                            EntertainmentId = x.Entertainment.EntertainmentId,
                            Status = x.Entertainment.Status,
                            EntertainmentTotal = x.Entertainment.EntertainmentTotal

                        },
                        EventBooker = new EventBooker
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname,
                            Email = x.EventBooker.Email,
                            Phone = x.EventBooker.Phone,
                            Address = x.EventBooker.Address,
                            RegisterDate = x.EventBooker.RegisterDate,
                            Gender = x.EventBooker.Gender,
                            DateOfBirth = x.EventBooker.DateOfBirth,
                            Image = x.EventBooker.Image,
                            Status = x.EventBooker.Status,
                        },
                    })
                    //.Include(x => x.EventBooker)
                    //.Include(x => x.Menu)
                    //.Include(x => x.Decoration)
                    //.Include(x => x.Script)
                    //.Include(x => x.Entertainment)
                    .FirstOrDefaultAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    this.context.Event.LoadAsync();
                    return Event;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Event GetEventByID1(string id)
        {
            try
            {
                var Event = this.context.Event
                    .Where(x => x.EventId == id && x.Status).FirstOrDefault();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    return Event;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task <List<Event>> GetEventByBookerID(string id)
        {
            try
            {
                var Event = await this.context.Event
                    .Where(x => x.EventBookerId.Equals(id) && x.Status).Select(x => new Event
                    {
                        EventId = x.EventId,
                        ScriptId = x.ScriptId,
                        DecorationId = x.DecorationId,
                        EventTypeId = x.EventTypeId,
                        MenuId = x.MenuId,
                        EntertainmentId = x.EntertainmentId,
                        EventBookerId = x.EventBookerId,
                        OrganizedPerson = x.OrganizedPerson,
                        StartDate = x.StartDate,
                        TotalPrice = x.TotalPrice,
                        EndDate = x.EndDate,
                        Status = x.Status,
                        Script = new Script
                        {
                            Id = x.Script.Id,
                            ScriptName = x.Script.ScriptName,
                            Status = x.Script.Status,
                            ScriptContent = x.Script.ScriptContent,
                        },
                        Decoration = new Decoration
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,

                        },
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName,
                            EventTypeImage = x.EventType.EventTypeImage,
                            EventTypeDescription = x.EventType.EventTypeDescription,
                        },
                        Menu = new Menu
                        {
                            MenuId = x.Menu.MenuId,
                            MenuName = x.Menu.MenuName,
                            Status = x.Menu.Status,
                            PriceTotal = x.Menu.PriceTotal,
                        },
                        Entertainment = new Entertainment
                        {
                            EntertainmentId = x.Entertainment.EntertainmentId,
                            Status = x.Entertainment.Status,
                            EntertainmentTotal = x.Entertainment.EntertainmentTotal

                        },
                        EventBooker = new EventBooker
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname,
                            Email = x.EventBooker.Email,
                            Phone = x.EventBooker.Phone,
                            Address = x.EventBooker.Address,
                            RegisterDate = x.EventBooker.RegisterDate,
                            Gender = x.EventBooker.Gender,
                            DateOfBirth = x.EventBooker.DateOfBirth,
                            Image = x.EventBooker.Image,
                            Status = x.EventBooker.Status,
                        },
                    })
                    //.Include(x => x.EventBooker)
                    //.Include(x => x.Menu)
                    //.Include(x => x.Decoration)
                    //.Include(x => x.Script)
                    //.Include(x => x.Entertainment)
                    .ToListAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    this.context.Event.LoadAsync();
                    return Event;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Script> GetScriptByEvent(string Eventid)
        {
            try
            {
                Event Event = await this.context.Event.Where(x => x.EventId.Equals(Eventid)).FirstOrDefaultAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    var Script = await this.context.Script.Where(x => x.Status && x.Id.Equals(Event.ScriptId)).FirstOrDefaultAsync();
                    return Script;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Product>> GetProductDecorationByEvent(string Eventid)
        {
            try
            {
                var Event = await this.context.Event.Where(x => x.EventId.Equals(Eventid)).FirstOrDefaultAsync();

                if (Event == null)
                {
                    return null;
                }
                else
                {
                    //var decoration = await this.context.Decoration.Where(x => x.DecorationId.Equals(Eventid)).FirstOrDefaultAsync();
                    //var decoproduct = await this.context.DecorationProduct.Where(x=>x.DecorationId.Equals(decoration.DecorationId)).ToListAsync();
                    //return decoproduct;
                    var deco = await this.context.DecorationProduct.Where(x => x.DecorationId == Event.DecorationId)
                        .Select(x=> new Product
                        {
                            ProductId = x.Product.ProductId,
                            ProductDetails = x.Product.ProductDetails,
                            ProductImage= x.Product.ProductImage,
                            ProductPrice= x.Product.ProductPrice,
                            ProductSupplier= x.Product.ProductSupplier,
                        }).ToListAsync();
                    var result = new List<Product>();
                    foreach (var item in deco)
                    {
                        var check = await this.context.Product.Where(x => x.ProductId == item.ProductId).FirstOrDefaultAsync();
                        result.Add(check);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FoodDto>> GetMenuByEvent(string Eventid)
        {
            try
            {
                var Event = await this.context.Event.Where(x=>x.EventId.Equals(Eventid)).FirstOrDefaultAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    var menuproduct = await this.context.MenuProduct.Where(x => x.MenuId.Equals(Event.MenuId)).ToListAsync();
                    var result = new List<FoodDto>();
                    foreach (var item in menuproduct)
                    {
                        var food = await this.context.Food.Where(x => x.FoodId.Equals(item.Product)).FirstOrDefaultAsync();
                        if(food != null)
                        {

                            result.Add(new FoodDto
                            {
                                CookingRecipe = food.CookingRecipe,
                                Dish = food.Dish,
                                FoodDescription= food.FoodDescription,
                                FoodId= food.FoodId,
                                FoodImage= food.FoodImage,
                                FoodName= food.FoodName,
                                FoodOrigin= food.FoodOrigin,    
                                FoodIngredient = food.FoodIngredient,
                                FoodPrice= item.Price,
                                FoodTypeId= food.FoodTypeId,
                                Status = food.Status
                            });
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<EntertainmentProduct>> GetEntertainmentByEvent(string Eventid)
        {
            try
            {
                var Event = await this.context.Event.Where(x => x.EventId.Equals(Eventid)).FirstOrDefaultAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    var entertainmentproduct = await this.context.EntertainmentProduct
                        //.Include(x=>x.Game) //Product
                        //.Include(x=>x.Show)//ProductNavigation
                        .Where(x => x.EntertainmentId.Equals(Event.EntertainmentId))
                        .Select(x => new EntertainmentProduct
                        {
                            EntertainmentId = x.EntertainmentId,
                            ProductId = x.ProductId,
                            ShowId = x.ShowId,
                            GameId = x.GameId,
                            EntertainmentProductPrice = x.EntertainmentProductPrice,
                            Quantity = x.Quantity,

                            Entertainment = new Entertainment
                            {
                                EntertainmentId = x.Entertainment.EntertainmentId,
                                EntertainmentTotal = x.Entertainment.EntertainmentTotal,
                                Status = true

                            },
                            Game = new GameServices
                            {
                                GameId = x.Game.GameId,
                                GameName = x.Game.GameName,
                                //GameServicePrice = x.Game.GameServicePrice,
                                GameDetails = x.Game.GameDetails,
                                GameRules = x.Game.GameRules,
                                GameReward = x.Game.GameReward,
                                Supplies = x.Game.Supplies,
                                GameImage = x.Game.GameImage,
                                //Status = x.Game.Status,
                            },
                            Show = new ShowService
                            {
                                ShowId = x.Show.ShowId,
                                //ShowPrice = x.Show.ShowPrice,
                                ShowServiceName = x.Show.ShowServiceName,
                                Light = x.Show.Light,
                                Sound = x.Show.Sound,
                                Singer = x.Show.Singer,
                                ShowDescription = x.Show.ShowDescription,
                                ShowImage = x.Show.ShowImage,
                                //Status = x.Show.Status,
                            },
                        })
                    .ToListAsync();
                    return entertainmentproduct;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Event>> GetEventByDay(string eventbooker, DateTime minDate, DateTime maxDate)
        {
            try
            {
                var Event = await this.context.Event.Where(x=>x.EventBookerId.Equals(eventbooker) &&x.Status)
                    .Select(x => new Event
                    {
                        EventId = x.EventId,
                        ScriptId = x.ScriptId,
                        DecorationId = x.DecorationId,
                        EventTypeId = x.EventTypeId,
                        MenuId = x.MenuId,
                        EntertainmentId = x.EntertainmentId,
                        EventBookerId = x.EventBookerId,
                        OrganizedPerson = x.OrganizedPerson,
                        StartDate = x.StartDate,
                        TotalPrice = x.TotalPrice,
                        EndDate = x.EndDate,
                        Status = x.Status,
                        Script = new Script
                        {
                            Id = x.Script.Id,
                            ScriptName = x.Script.ScriptName,
                            Status = x.Script.Status,
                            ScriptContent = x.Script.ScriptContent,
                        },
                        Decoration = new Decoration
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,

                        },
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName,
                            EventTypeImage = x.EventType.EventTypeImage,
                            EventTypeDescription = x.EventType.EventTypeDescription,
                        },
                        Menu = new Menu
                        {
                            MenuId = x.Menu.MenuId,
                            MenuName = x.Menu.MenuName,
                            Status = x.Menu.Status,
                            PriceTotal = x.Menu.PriceTotal,
                        },
                        Entertainment = new Entertainment
                        {
                            EntertainmentId = x.Entertainment.EntertainmentId,
                            Status = x.Entertainment.Status,
                            EntertainmentTotal = x.Entertainment.EntertainmentTotal

                        },
                        EventBooker = new EventBooker
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname,
                            Email = x.EventBooker.Email,
                            Phone = x.EventBooker.Phone,
                            Address = x.EventBooker.Address,
                            RegisterDate = x.EventBooker.RegisterDate,
                            Gender = x.EventBooker.Gender,
                            DateOfBirth = x.EventBooker.DateOfBirth,
                            Image = x.EventBooker.Image,
                            Status = x.EventBooker.Status,
                        },
                    })
                    //.Include(x => x.EventBooker)
                    //.Include(x => x.Menu)
                    //.Include(x => x.Decoration)
                    //.Include(x => x.Script)
                    //.Include(x => x.Entertainment)
                    .ToListAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    var result = new List<Event>();
                    foreach (var item in Event)
                    {
                        if (item.StartDate >= minDate && item.EndDate <= maxDate)
                        {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Event>> GetEventByDayForAdmin(DateTime minDate, DateTime maxDate)
        {
            try
            {
                var Event = await this.context.Event.Where(x=>x.Status)
                    .Select(x => new Event
                    {
                        EventId = x.EventId,
                        ScriptId = x.ScriptId,
                        DecorationId = x.DecorationId,
                        EventTypeId = x.EventTypeId,
                        MenuId = x.MenuId,
                        EntertainmentId = x.EntertainmentId,
                        EventBookerId = x.EventBookerId,
                        OrganizedPerson = x.OrganizedPerson,
                        StartDate = x.StartDate,
                        TotalPrice = x.TotalPrice,
                        EndDate = x.EndDate,
                        Status = x.Status,
                        Script = new Script
                        {
                            Id = x.Script.Id,
                            ScriptName = x.Script.ScriptName,
                            Status = x.Script.Status,
                            ScriptContent = x.Script.ScriptContent,
                        },
                        Decoration = new Decoration
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,

                        },
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName,
                            EventTypeImage = x.EventType.EventTypeImage,
                            EventTypeDescription = x.EventType.EventTypeDescription,
                        },
                        Menu = new Menu
                        {
                            MenuId = x.Menu.MenuId,
                            MenuName = x.Menu.MenuName,
                            Status = x.Menu.Status,
                            PriceTotal = x.Menu.PriceTotal,
                        },
                        Entertainment = new Entertainment
                        {
                            EntertainmentId = x.Entertainment.EntertainmentId,
                            Status = x.Entertainment.Status,
                            EntertainmentTotal = x.Entertainment.EntertainmentTotal

                        },
                        EventBooker = new EventBooker
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname,
                            Email = x.EventBooker.Email,
                            Phone = x.EventBooker.Phone,
                            Address = x.EventBooker.Address,
                            RegisterDate = x.EventBooker.RegisterDate,
                            Gender = x.EventBooker.Gender,
                            DateOfBirth = x.EventBooker.DateOfBirth,
                            Image = x.EventBooker.Image,
                            Status = x.EventBooker.Status,
                        },
                    })
                    //.Include(x => x.EventBooker)
                    //.Include(x => x.Menu)
                    //.Include(x => x.Decoration)
                    //.Include(x => x.Script)
                    //.Include(x => x.Entertainment)
                    .ToListAsync();
                if (Event == null)
                {
                    return null;
                }
                else
                {
                    var result = new List<Event>();
                    foreach (var item in Event)
                    {
                        if (item.StartDate >= minDate && item.EndDate <= maxDate)
                        {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> disableEvent()
        {
            try
            {
                var checkpay = await this.context.Payment.ToListAsync();
                var ev = await this.context.Event.ToListAsync();
                foreach(var item in checkpay)
                {
                    foreach(var eve in ev)
                    {
                        if(item.Status && item.EventId.Equals(eve.EventId))
                        {
                            DateTime min = Convert.ToDateTime(eve.StartDate);
                            DateTime max = Convert.ToDateTime(item.Date);
                            TimeSpan Time = max - min;
                            int check = Time.Days;
                            if(check <= 7)
                            {
                                eve.Status = true;
                            }
                            else
                            {
                                eve.Status = false;
                            }
                            return true;
                        }
                    }
                }
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ResponeEventAll> ExportData(string eventid)
        {
            try
            {
                var result = new ResponeEventAll();
                var ev = await this.context.Event.Where(x=>x.EventId.Equals(eventid)).FirstOrDefaultAsync();
                if (ev != null)
                {
                    result.StartDate = ev.StartDate;
                    result.EndDate = ev.EndDate;
                    result.Status = ev.Status;
                    result.EventId = ev.EventId;
                    result.ScriptId = ev.ScriptId;
                    result.DecorationId = ev.DecorationId;
                    result.EntertainmentId = ev.EntertainmentId;
                    result.TotalPrice = ev.TotalPrice;
                    result.OrganizedPerson = ev.OrganizedPerson;
                    result.MenuId = ev.MenuId;

                    //menu
                    var menu = await this.context.MenuProduct.Where(x => x.MenuId.Equals(ev.MenuId)).ToListAsync();
                    result.foods = new List<FoodRespone>();
                    foreach (var item in menu)
                    {
                        var product = await this.context.Food.Where(x => x.FoodId.Equals(item.Product))
                            .Select(x=> new Food
                            {
                                FoodId = x.FoodId,
                                FoodImage = x.FoodImage,
                                FoodName= x.FoodName,
                                FoodType= new FoodType
                                {
                                    FoodTypeName = x.FoodType.FoodTypeName
                                }
                            })
                            .FirstOrDefaultAsync();
                        if(product != null)
                        {
                            //var FoodTypeId = product.FoodType.FoodTypeName;
                            var f = new FoodRespone();
                            f.FoodId = product.FoodId;
                            f.FoodImage = product.FoodImage;
                            f.FoodName = product.FoodName;
                            f.FoodPrice = item.Price;
                            f.FoodTypeId = product.FoodType.FoodTypeName;
                            result.foods.Add(f);
                            //result.foods.Add(new FoodRespone
                            //{
                            //    FoodId = product.FoodId,
                            //    FoodImage= product.FoodImage,
                            //    FoodName= product.FoodName,
                            //    FoodPrice = item.Price,
                            //    //FoodTypeId= product.FoodType.FoodTypeName,
                            //});
                        }
                    }
                    
                    // decoration
                    var decoration = await this.context.DecorationProduct.Where(x=>x.DecorationId.Equals(ev.DecorationId)).ToListAsync();
                    result.products = new List<ProductRespone>();
                    foreach (var item in decoration)
                    {
                        var product = await this.context.Product.Where(x => x.ProductId.Equals(item.ProductId))
                            .Select(x=> new Product
                            {
                                ProductId= x.ProductId,
                                DecorationProductName = x.DecorationProductName,
                                ProductImage = x.ProductImage,
                            })
                            .FirstOrDefaultAsync();
                        if (product != null)
                        {
                            result.products.Add(new ProductRespone
                            {
                                ProductId = product.ProductId,
                                DecorationProductName= product.DecorationProductName,
                                ProductImage= product.ProductImage,
                                ProductPrice= item.Price,
                                ProductQuantity = item.Quantity,
                            });
                        }
                    }

                    //entertainment
                    var entertainment = await this.context.EntertainmentProduct.Where(x=>x.EntertainmentId.Equals(ev.EntertainmentId)).ToListAsync();
                    result.gameServices = new List<GameRespone>();
                    result.showServices = new List<ShowRespone>();
                    foreach (var item in entertainment)
                    {
                        if(item.GameId == null && item.ShowId != null) 
                        {
                            var show = await this.context.ShowService.Where(x => x.ShowId.Equals(item.ShowId))
                                .Select(x=> new ShowService
                                {
                                    ShowId = x.ShowId,
                                    ShowImage = x.ShowImage,
                                    ShowServiceName = x.ShowServiceName,
                                })
                                .FirstOrDefaultAsync();
                            if(show != null)
                            {
                                result.showServices.Add(new ShowRespone
                                {
                                    ShowId = show.ShowId,
                                    ShowImage= show.ShowImage,
                                    ShowName = show.ShowServiceName,
                                    Quantity = item.Quantity,
                                    ShowServicePrice = 10000
                                });
                            }
                        }
                        if(item.GameId != null && item.ShowId == null)
                        {
                            var game = await this.context.GameServices.Where(x => x.GameId.Equals(item.GameId))
                                .Select(x => new GameServices
                                {
                                    GameId = x.GameId,
                                    GameName = x.GameName,
                                    GameImage = x.GameImage,
                                })
                                .FirstOrDefaultAsync();
                            if(game != null)
                            {
                                result.gameServices.Add(new GameRespone
                                {
                                    GameId = game.GameId,
                                    GameImage= game.GameImage,
                                    GameName= game.GameName,
                                    Quantity = item.Quantity,
                                    GameServicePrice = 10000
                                });
                            }
                        }
                    }

                    //datetime
                    result.DateTimeRespone = new DateTimeRespone();
                    var datetime = await this.context.DateTimeLocation.Where(x => x.EventId.Equals(ev.EventId) && x.Status == 1 && x.Date < ev.EndDate)
                        .Select(x=> new DateTimeLocation
                        {
                            Date= x.Date,
                            RoomId=x.RoomId,
                            Status=x.Status,
                            Room = new RoomLocation
                            {
                                RoomName=x.Room.RoomName,
                                RoomImage = x.Room.RoomImage,
                                RoomDescription = x.Room.RoomDescription
                            }
                        })
                        .FirstOrDefaultAsync();
                    if(datetime!= null)
                    {
                        result.DateTimeRespone.Date = datetime.Date;
                        result.DateTimeRespone.RoomDescription = datetime.Room.RoomDescription;
                        result.DateTimeRespone.RoomName = datetime.Room.RoomName;
                        result.DateTimeRespone.RoomImage = datetime.Room.RoomImage;
                        result.DateTimeRespone.RoomId = datetime.RoomId;
                    }

                    //eventbooker
                    result.EventBooker = new BookerRespone();
                    var booker = await this.context.EventBooker.Where(x => x.EventBookerId.Equals(ev.EventBookerId))
                        .Select(x=> new EventBooker
                        {
                            EventBookerId= x.EventBookerId,
                            Fullname = x.Fullname,
                            Email = x.Email,
                            Phone = x.Phone,
                            Address = x.Address,
                        })
                        .FirstOrDefaultAsync();
                    if(booker!= null)
                    {
                        result.EventBooker.Address=booker.Address;
                        result.EventBooker.Email=booker.Email;
                        result.EventBooker.EventBookerId = booker.EventBookerId;
                        result.EventBooker.Phone = booker.Phone;
                        result.EventBooker.Fullname=booker.Fullname;
                    }

                    //verify
                    result.VerifyRespone = new VerifyRespone();
                    var verify = await this.context.Verify.Where(x=>x.EventId.Equals(ev.EventId)).Select(x=> new Verify
                    {
                        VerifyId= x.VerifyId,
                        VerifyCode  = x.VerifyCode,
                    })
                        .FirstOrDefaultAsync();
                    if(verify!= null)
                    {
                        result.VerifyRespone.VerifyId = verify.VerifyId;
                        result.VerifyRespone.VerifyCode = verify.VerifyCode;
                    }

                    //script
                    result.ScriptRespone= new ScriptRespone();
                    var script = await this.context.Script.Where(x => x.Id.Equals(ev.ScriptId))
                        .Select(x=> new Script
                        {
                            Id= x.Id,
                            ScriptName= x.ScriptName,
                            ScriptContent   = x.ScriptContent,
                        }).FirstOrDefaultAsync();
                    if(script!= null)
                    {
                        result.ScriptRespone.Id = script.Id;
                        result.ScriptRespone.ScriptName = script.ScriptName;
                        result.ScriptRespone.ScriptContent = script.ScriptContent;
                    }

                    //event type
                    result.evt = new EventTypeRespone();
                    var eventType = await this.context.EventType.Where(x => x.EventTypeId.Equals(ev.EventTypeId)).Select(x => new EventType
                    {
                        EventTypeName = x.EventTypeName,
                        EventTypeId = x.EventTypeId,
                        EventTypeImage = x.EventTypeImage,
                    }).FirstOrDefaultAsync();
                    if (eventType != null)
                    {
                        result.evt.EventTypeName = eventType.EventTypeName;
                        result.evt.EventTypeId = eventType.EventTypeId;
                        result.evt.EventTypeImage = eventType.EventTypeImage;
                    }

                }
                return result;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ResponeEventAll>> ExportDataMobile(string eventbooker)
        {
            try
            {
                var final = new List<ResponeEventAll>();
                var result = new ResponeEventAll();
                var eventcheck = await this.context.Event.Where(x => x.EventBookerId.Equals(eventbooker) && x.Status).Select(x => new Event
                {
                    EventId = x.EventId,
                }).ToListAsync();
                if (eventcheck == null)
                {
                    return null;
                }
                else
                {
                    foreach (var even in eventcheck)
                    {
                        var ev = await this.context.Event.Where(x => x.EventId.Equals(even.EventId))
                            .Select(x=> new Event
                            {
                                DecorationId =x.DecorationId,
                                EndDate=x.EndDate,
                                EntertainmentId = x.EntertainmentId,
                                EventBookerId = x.EventBookerId,
                                EventTypeId = x.EventTypeId,
                                MenuId = x.MenuId,
                                ScriptId= x.ScriptId,
                                TotalPrice = x.TotalPrice,
                                OrganizedPerson = x.OrganizedPerson,
                                StartDate= x.StartDate,
                                EventId = x.EventId,
                                Status = x.Status
                            })
                            .FirstOrDefaultAsync();
                        if (ev != null)
                        {
                            result.StartDate = ev.StartDate;
                            result.EndDate = ev.EndDate;
                            result.Status = ev.Status;
                            result.EventId = ev.EventId;
                            result.ScriptId = ev.ScriptId;
                            result.DecorationId = ev.DecorationId;
                            result.EntertainmentId = ev.EntertainmentId;
                            result.TotalPrice = ev.TotalPrice;
                            result.OrganizedPerson = ev.OrganizedPerson;
                            result.MenuId = ev.MenuId;
                            result.Status = ev.Status;

                            //menu
                            var menu = await this.context.MenuProduct.Where(x => x.MenuId.Equals(ev.MenuId)).ToListAsync();
                            result.foods = new List<FoodRespone>();
                            var m = await this.context.Menu.Where(x => x.MenuId.Equals(ev.MenuId)).FirstOrDefaultAsync();
                            result.MenuName = m.MenuName;
                            result.QuantityTable = m.TableQuantity;
                            foreach (var item in menu)
                            {
                                var product = await this.context.Food.Where(x => x.FoodId.Equals(item.Product))
                                    .Select(x => new Food
                                    {
                                        FoodId = x.FoodId,
                                        FoodImage = x.FoodImage,
                                        FoodName = x.FoodName,
                                        FoodType = new FoodType
                                        {
                                            FoodTypeName = x.FoodType.FoodTypeName
                                        }
                                    })
                                    .FirstOrDefaultAsync();
                                if (product != null)
                                {
                                    //var FoodTypeId = product.FoodType.FoodTypeName;
                                    var f = new FoodRespone();
                                    f.FoodId = product.FoodId;
                                    f.FoodImage = product.FoodImage;
                                    f.FoodName = product.FoodName;
                                    f.FoodPrice = item.Price;
                                    f.FoodTypeId = product.FoodType.FoodTypeName;
                                    f.Quantity = item.Quatity;
                                    result.foods.Add(f);
                                }
                                
                            }

                            // decoration
                            var decoration = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(ev.DecorationId)).ToListAsync();
                            result.products = new List<ProductRespone>();
                            foreach (var item in decoration)
                            {
                                var product = await this.context.Product.Where(x => x.ProductId.Equals(item.ProductId))
                                    .Select(x => new Product
                                    {
                                        ProductId = x.ProductId,
                                        DecorationProductName = x.DecorationProductName,
                                        ProductImage = x.ProductImage,
                                    })
                                    .FirstOrDefaultAsync();
                                if (product != null)
                                {
                                    result.products.Add(new ProductRespone
                                    {
                                        ProductId = product.ProductId,
                                        DecorationProductName = product.DecorationProductName,
                                        ProductImage = product.ProductImage,
                                        ProductPrice = item.Price,
                                        ProductQuantity = item.Quantity,
                                    });
                                }
                            }

                            //entertainment
                            var entertainment = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId)).ToListAsync();
                            result.gameServices = new List<GameRespone>();
                            result.showServices = new List<ShowRespone>();
                            foreach (var item in entertainment)
                            {
                                if (item.GameId == null && item.ShowId != null)
                                {
                                    var show = await this.context.ShowService.Where(x => x.ShowId.Equals(item.ShowId))
                                        .Select(x => new ShowService
                                        {
                                            ShowId = x.ShowId,
                                            ShowImage = x.ShowImage,
                                            ShowServiceName = x.ShowServiceName,
                                        })
                                        .FirstOrDefaultAsync();
                                    if (show != null)
                                    {
                                        result.showServices.Add(new ShowRespone
                                        {
                                            ShowId = show.ShowId,
                                            ShowImage = show.ShowImage,
                                            ShowName = show.ShowServiceName,
                                            Quantity = item.Quantity,
                                            ShowServicePrice = 100000
                                        });
                                    }
                                }
                                if (item.GameId != null && item.ShowId == null)
                                {
                                    var game = await this.context.GameServices.Where(x => x.GameId.Equals(item.GameId))
                                        .Select(x => new GameServices
                                        {
                                            GameId = x.GameId,
                                            GameName = x.GameName,
                                            GameImage = x.GameImage,
                                        })
                                        .FirstOrDefaultAsync();
                                    if (game != null)
                                    {
                                        result.gameServices.Add(new GameRespone
                                        {
                                            GameId = game.GameId,
                                            GameImage = game.GameImage,
                                            GameName = game.GameName,
                                            Quantity = item.Quantity,
                                            GameServicePrice = 100000
                                        });
                                    }
                                }
                            }

                            //datetime
                            result.DateTimeRespone = new DateTimeRespone();
                            var datetime = await this.context.DateTimeLocation.Where(x => x.EventId.Equals(ev.EventId) && x.Status == 1 && x.Date < ev.EndDate)
                                .Select(x => new DateTimeLocation
                                {
                                    Date = x.Date,
                                    RoomId = x.RoomId,
                                    Status = x.Status,
                                    Room = new RoomLocation
                                    {
                                        RoomName = x.Room.RoomName,
                                        RoomImage = x.Room.RoomImage,
                                        RoomDescription = x.Room.RoomDescription
                                    }
                                })
                                .FirstOrDefaultAsync();
                            if (datetime != null)
                            {
                                result.DateTimeRespone.Date = datetime.Date;
                                result.DateTimeRespone.RoomDescription = datetime.Room.RoomDescription;
                                result.DateTimeRespone.RoomName = datetime.Room.RoomName;
                                result.DateTimeRespone.RoomImage = datetime.Room.RoomImage;
                                result.DateTimeRespone.RoomId = datetime.RoomId;
                            }

                            //eventbooker
                            result.EventBooker = new BookerRespone();
                            var booker = await this.context.EventBooker.Where(x => x.EventBookerId.Equals(ev.EventBookerId))
                                .Select(x => new EventBooker
                                {
                                    EventBookerId = x.EventBookerId,
                                    Fullname = x.Fullname,
                                    Email = x.Email,
                                    Phone = x.Phone,
                                    Address = x.Address,
                                })
                                .FirstOrDefaultAsync();
                            if (booker != null)
                            {
                                result.EventBooker.Address = booker.Address;
                                result.EventBooker.Email = booker.Email;
                                result.EventBooker.EventBookerId = booker.EventBookerId;
                                result.EventBooker.Phone = booker.Phone;
                                result.EventBooker.Fullname = booker.Fullname;
                            }

                            //verify
                            result.VerifyRespone = new VerifyRespone();
                            var verify = await this.context.Verify.Where(x => x.EventId.Equals(ev.EventId)).Select(x => new Verify
                            {
                                VerifyId = x.VerifyId,
                                VerifyCode = x.VerifyCode,
                            })
                                .FirstOrDefaultAsync();
                            if (verify != null)
                            {
                                result.VerifyRespone.VerifyId = verify.VerifyId;
                                result.VerifyRespone.VerifyCode = verify.VerifyCode;
                            }

                            //script
                            result.ScriptRespone = new ScriptRespone();
                            var script = await this.context.Script.Where(x => x.Id.Equals(ev.ScriptId))
                                .Select(x => new Script
                                {
                                    Id = x.Id,
                                    ScriptName = x.ScriptName,
                                    ScriptContent = x.ScriptContent,
                                }).FirstOrDefaultAsync();
                            if (script != null)
                            {
                                result.ScriptRespone.Id = script.Id;
                                result.ScriptRespone.ScriptName = script.ScriptName;
                                result.ScriptRespone.ScriptContent = script.ScriptContent;
                            }

                            //event type
                            result.evt = new EventTypeRespone();
                            var eventType = await this.context.EventType.Where(x => x.EventTypeId.Equals(ev.EventTypeId)).Select(x => new EventType
                            {
                                EventTypeName = x.EventTypeName,
                                EventTypeId = x.EventTypeId,
                                EventTypeImage = x.EventTypeImage,
                            }).FirstOrDefaultAsync();
                            if (eventType != null)
                            {
                                result.evt.EventTypeName = eventType.EventTypeName;
                                result.evt.EventTypeId = eventType.EventTypeId;
                                result.evt.EventTypeImage = eventType.EventTypeImage;
                            }
                            final.Add(result);
                            result = new ResponeEventAll();
                        }
                        else
                        {
                            return new List<ResponeEventAll>();
                        }
                    }
                }
                return final;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
