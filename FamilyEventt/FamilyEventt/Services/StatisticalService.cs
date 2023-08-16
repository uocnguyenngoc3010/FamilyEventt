using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using GoogleApi.Entities.Search.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FamilyEventt.Services
{
    public class StatisticalService : IStatistical
    {
        protected readonly FamilyEventContext context;

        public StatisticalService(FamilyEventContext context)
        {
            this.context = context;
        }

        

        public async Task<List<StatisticalDto>> StatisticalDataByType(int type, DateTime StartDate, DateTime EndDate)

        {
            int count = 0;
            decimal total = 0;
            if(StartDate > EndDate) {
                var tmp = StartDate;
                StartDate = EndDate;
                EndDate = tmp;
            }
            if(type < 0)
            {
                return null;
            }
            List<StatisticalDto> statistical = new List<StatisticalDto>();
            try
            {
                statistical.Clear();
                count = 0;
                total= 0;
                switch (type)
                {
                    case 0://event
                        var evnt = await this.context.Event.Where(x=>x.Status).ToListAsync();
                        foreach(var ev in evnt)
                        {
                            if(ev.StartDate >= StartDate && ev.EndDate <= EndDate)
                            {
                                count++;
                            }
                        }
                        //foreach (var x in evnt)
                        //{
                        //    count++;
                        //}
                        statistical.Add(new StatisticalDto
                        {
                            count = count,
                            StartDate = StartDate,
                            Enddate= EndDate
                        });
                        count = 0;
                        return statistical;
                        break; 
                    case 1://event booker
                        var evntBooker = await this.context.EventBooker.Where(x=>x.Status).ToListAsync();
                        foreach (var ev in evntBooker)
                        {
                            if(ev.RegisterDate>StartDate && ev.RegisterDate <= EndDate)
                            {
                                count++;
                            }
                        }
                        statistical.Add(new StatisticalDto
                        {
                            count = count,
                        });
                        count = 0;
                        return statistical;
                        break; 
                    case 2://event type
                        var eventType = await this.context.EventType.ToListAsync();
                        var dtl = await this.context.DateTimeLocation.ToListAsync();
                        var list = new List<Event>();
                        foreach (var e in dtl)
                        {
                            var eventt = await this.context.Event.Where(x => x.EventId.Equals(e.EventId))
                                .Select(x => new Event
                                {
                                    EventTypeId =x.EventTypeId,
                                    EventType = new EventType
                                    {
                                        EventTypeName = x.EventType.EventTypeName
                                    }
                                })
                                .FirstOrDefaultAsync();
                            
                            list.Add(eventt);
                            
                        }
                        foreach (var et in eventType)
                        {
                            foreach(var item in list)
                            {
                                if (et.EventTypeId.Equals(item.EventTypeId))
                                {
                                    count++;
                                }
                            }
                            if(count > 0)
                            {
                                statistical.Add(new StatisticalDto
                                {
                                    count = count,
                                    StartDate = StartDate,
                                    Enddate = EndDate,
                                    StatisticalID = et.EventTypeName
                                });
                                count = 0;
                            }
                            
                        }
                        return statistical;
                        break; 
                    case 3://food
                        var food = await this.context.Food.Where(x=>x.Status).ToListAsync();
                        var foodtmp = new List<MenuProduct>();
                        var dlt3= await this.context.DateTimeLocation.Where(x=>x.Date < EndDate && x.Date > StartDate && x.Status ==1).ToListAsync();
                        foreach (var item in dlt3)
                        {
                            var eve3 = await this.context.Event.Where(x => x.EventId.Equals(item.EventId)).FirstOrDefaultAsync();
                            var menuproduct = await this.context.MenuProduct.Where(m => m.MenuId.Equals(eve3.MenuId)).ToListAsync();

                            foreach (var e in menuproduct)
                            {
                                foodtmp.Add(e);
                            }
                        }
                        foreach (var x in food)
                        {
                            foreach (var mn in foodtmp)
                            {
                                if (x.FoodId.Equals(mn.Product))
                                {
                                    count++;
                                }
                            }
                            if (count > 0)
                            {
                                statistical.Add(new StatisticalDto
                                {
                                    count = count,
                                    StatisticalID = x.FoodName,
                                    Enddate = EndDate,
                                    StartDate = StartDate,
                                });
                                count = 0;
                            }
                        }         
                        return statistical;
                        break;
                    case 4://decoration product
                        var product = await this.context.Product.Where(x => x.Status).ToListAsync();
                        var decotmp = new List<DecorationProduct>();
                        var dtl4 = await this.context.DateTimeLocation.Where(x => x.Date < EndDate && x.Date > StartDate && x.Status == 1).ToListAsync();
                        foreach( var ite in dtl4)
                        {
                            var c4 = await this.context.Event.Where(x => x.EventId.Equals(ite.EventId)).FirstOrDefaultAsync();
                            var decoproduct = await this.context.DecorationProduct.Where(t=>t.DecorationId.Equals(c4.DecorationId)).ToListAsync();
                            
                                foreach (var e in decoproduct)
                                {
                                    decotmp.Add(e);
                                }
                        }
                        foreach(var x in product)
                        {
                            foreach(var dec in decotmp)
                            {
                                if (x.ProductId.Equals(dec.ProductId))
                                {
                                    count++;
                                }
                            }
                            if (count > 0)
                            {
                                statistical.Add(new StatisticalDto
                                {
                                    count = count,
                                    StatisticalID = x.DecorationProductName,
                                    Enddate = EndDate,
                                    StartDate = StartDate,
                                });
                                count = 0;
                            }
                        }
                        
                        return statistical;
                        break;
                    case 5:// room
                        var room = await this.context.RoomLocation.Where(x => x.Status).ToListAsync();
                        var datetimelocation = await this.context.DateTimeLocation.Where(x=>x.Date<EndDate && x.Date>StartDate).ToListAsync();
                        foreach (var x in room)
                        {
                            foreach (var e in datetimelocation)
                            {
                                if (x.RoomId.Equals(e.RoomId))
                                {
                                    count++;
                                }
                            }
                            statistical.Add(new StatisticalDto
                            {
                                count = count,
                                StartDate = StartDate,
                                Enddate = EndDate,
                                StatisticalID = x.RoomName
                            });
                            count = 0;
                        }
                        break;
                    case 6://event type in date
                        var dtl6 = await this.context.DateTimeLocation.Where(x=>x.Date<EndDate &&x.Date>StartDate && x.Status==1).ToListAsync();
                        var eventType6 = await this.context.EventType.ToListAsync();
                        var liev = new List<Event>();
                        foreach(var e in dtl6)
                        {
                            var eve6 =  await this.context.Event.Where(x => x.EventId.Equals(e.EventId))
                                .Select(x => new Event
                                {
                                    EventTypeId = x.EventTypeId,
                                    EventType = new EventType
                                    {
                                        EventTypeName = x.EventType.EventTypeName
                                    }
                                })
                                .FirstOrDefaultAsync();

                            liev.Add(eve6);
                        }
                        foreach (var e in eventType6) 
                        {
                            foreach(var item in liev)
                            {
                                if(item.EventTypeId.Equals(e.EventTypeId))
                                {
                                    count++;
                                }
                            }
                            if (count > 0)
                            {
                                statistical.Add(new StatisticalDto
                                {
                                    count = count,
                                    StartDate = StartDate,
                                    Enddate = EndDate,
                                    StatisticalID = e.EventTypeName
                                });
                                count = 0;
                            }
                        }
                        
                        return statistical;
                        break;
                    case 7:
                        var checkEV = await this.context.Event.Where(x => x.Status && x.StartDate >= StartDate && x.EndDate <= EndDate).ToListAsync();
                        foreach(var x in checkEV)
                        {
                            total += x.TotalPrice;
                            count++;
                        }
                        statistical.Add(new StatisticalDto
                        {
                            count = count,
                            TotalPrice= total,
                            StartDate = StartDate,
                            Enddate = EndDate,
                        });
                        count = 0;
                        return statistical;
                        break;
                    default:
                        return statistical;
                }

                return statistical;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
