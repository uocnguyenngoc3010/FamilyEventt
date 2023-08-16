using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Events.V1;

namespace FamilyEventt.Services
{
    public class EventTypeService : IEventType
    {
        protected readonly FamilyEventContext context;
        public EventTypeService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<List<EventType>> GetAllEvents()
        {
            try
            {
                var EventType = await this.context.EventType.ToListAsync();
                if (EventType == null) {
                    return null;
                }
                else 
                {
                    this.context.EventType.LoadAsync();
                    return EventType; 
                }

            }catch(Exception ex)
            {
                return null; 
            }
        }

        public async Task<bool> InsertEventType(EventTypeDto newEventType)
        {
            try
            {
                var type = new EventType();
                type.EventTypeId = "ETId" + Guid.NewGuid().ToString().Substring(0,19);
                type.EventTypeName = newEventType.EventTypeName;    
                type.EventTypeDescription = newEventType.EventTypeDescription;  
                type.EventTypeImage = newEventType.EventTypeImage;
                await this.context.EventType.AddAsync(type);
                await this.context.SaveChangesAsync();
                //this.context.EventType.LoadAsync();

                return true;
            }catch(Exception ex) { return false; }
        }

        /*public async Task<List<EventType>> SearchByNameEventType(string Name)
        {
            try
            {
                var EventType = await this.context.EventType.Where(x=>x.EventTypeName.Contains(Name)).ToListAsync();
                if (EventType == null)
                {
                    return null;
                }
                else {
                    this.context.EventType.LoadAsync(); 
                    return EventType; }

            }
            catch (Exception ex)
            {
                return null;
            }
        }*/
        public async Task<List<EventTypeDto>> FilterEventTypeByManyOption(string? name, string? id)
        {
            try
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                var data = await this.context.EventType
                                 .Where(x => id == null || x.EventTypeId == id)
                                 .ToListAsync();
                data = data.Where(x => name == null ? true : DataHelper.RemoveUnicode(x.EventTypeName).ToLower().Contains(name)).ToList();
                       var _eventType = data.Select (x => new EventTypeDto
                       {
                           EventTypeId = x.EventTypeId,
                           EventTypeName = x.EventTypeName,
                           EventTypeImage = x.EventTypeImage,
                           EventTypeDescription = x.EventTypeDescription,  
                       }).ToList();
                                 
                return _eventType;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }
        public async Task<bool> UpdateEventType(EventTypeDto uptEventDto)
        {
            try
            {
                var type = await this.context.EventType.Where(x=>x.EventTypeId==uptEventDto.EventTypeId).FirstOrDefaultAsync();
                if (type == null) {
                    return false;
                }
                else
                {
                    type.EventTypeName = uptEventDto.EventTypeName;
                    type.EventTypeDescription = uptEventDto.EventTypeDescription;
                    type.EventTypeImage = uptEventDto.EventTypeImage;
                    this.context.EventType.Update(type);
                    await this.context.SaveChangesAsync();
                    this.context.EventType.LoadAsync();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<List<EvenTypeRespone>> GetEventTypeByDate(DateTime date, string eventbooker)
        {
            try
            {
                List<EvenTypeRespone> result = new List<EvenTypeRespone>();
                var check = await this.context.Event.Where(x=>x.EventBookerId.Equals(eventbooker)).ToListAsync();
                if (check == null)
                {
                    return null;
                }
                else
                {
                    foreach(var item in check)
                    {
                        if(item.EndDate >= date)
                        {
                            var check2 = await this.context.EventType.Where(x=>x.EventTypeId.Equals(item.EventTypeId)).ToListAsync();
                            foreach(var item2 in check2)
                            {
                                result.Add(new EvenTypeRespone()
                                {
                                    Date = date,
                                    EventTypeId= item2.EventTypeId,
                                    EventTypeDescription= item2.EventTypeDescription,
                                    EventTypeImage= item2.EventTypeImage,
                                    EventTypeName = item2.EventTypeName,
                                    people = item.OrganizedPerson
                                });
                            }
                            
                        }
                    }
                    return result;
                }
            }catch(Exception ex)
            {
                return null;
            }
        } 
    }
}
