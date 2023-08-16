using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class BookingService : IBooking
    {
        protected readonly FamilyEventContext context;

        public BookingService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<List<DateTimeLocation>> CheckUsedRoomByDay(DateTime date)
        {
            //var result = new List<RoomLocation>();
            try
            {
                var check = await this.context.DateTimeLocation.Where(x => x.Date.Equals(date)).Select(x => new DateTimeLocation
                {
                    EventId = x.EventId,
                    RoomId = x.RoomId,
                    Date = x.Date,
                    Event = new Event
                    {
                        EventId = x.Event.EventId,
                        EventType = x.Event.EventType,
                        OrganizedPerson = x.Event.OrganizedPerson,
                    },
                    Room = new RoomLocation
                    {
                        RoomId = x.Room.RoomId,
                        RoomName = x.Room.RoomName,
                        RoomDescription = x.Room.RoomDescription,
                        RoomImage = x.Room.RoomImage,
                        Capacity = x.Room.Capacity,
                        Parking = x.Room.Parking
                    }
                }).ToListAsync();
                if (check.Any())
                {
                    return check;
                    //foreach (var room in check)
                    //{
                    //    var checkroom = await this.context.RoomLocation.Where(x=>x.Status && x.RoomId.Equals(room.RoomId)).FirstOrDefaultAsync();

                    //}
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

        public async Task<bool> BookingRoom(string eventID, string roomID, DateTime date)
        {
            try
            {
                var checkdate = await this.context.Event.Where(x => x.EventId.Equals(eventID)).FirstOrDefaultAsync();
                if(checkdate.EndDate< date)
                {
                    return false;
                }
                var check = await this.context.DateTimeLocation
                    .Where(x => x.RoomId.Equals(roomID) && x.Date.Equals(date) && x.Status == 1)
                    .FirstOrDefaultAsync();
                if (check == null)
                {
                    var insert = new DateTimeLocation();
                    insert.RoomId = roomID;
                    insert.EventId = eventID;
                    insert.Date = date;
                    insert.Status = 1;
                    await this.context.DateTimeLocation.AddAsync(insert);
                    this.context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoomLocation>> CheckEmptyRoomByDay(DateTime date)
        {

            try
            {
                List<RoomLocation> result = await this.context.RoomLocation.Where(x => x.Status).ToListAsync();
                var check = await this.context.DateTimeLocation.Where(x => x.Date.Equals(date) && x.Status == 1).ToListAsync();
                if (check.Any())
                {
                    foreach (var room in check)
                    {
                        var checkroom = await this.context.RoomLocation.Where(x => x.Status && x.RoomId.Equals(room.RoomId)).FirstOrDefaultAsync();
                        result.Remove(checkroom);
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteBooking(DateTimeLocationDto dto)
        {
            try
            {
                var check = await this.context.DateTimeLocation.Where(x => x.EventId.Equals(dto.EventId) 
                && x.RoomId.Equals(dto.RoomId)
                && x.Date.Equals(dto.Date)
                && x.Status == 1).FirstOrDefaultAsync();
                if (check == null)
                {
                    return false;
                }
                else
                {
                    check.Status = 0;
                    await this.context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<DateTimeLocation>> GetDateTimeLocationByEventBooker(string id)
        {
            try
            {
                var result = new List<DateTimeLocation>();
                var check = await this.context.Event.Where(x => x.EventBookerId.Equals(id) && x.Status).ToListAsync();
                if (check == null)
                {
                    return null;
                }
                else
                {
                    foreach(var item in check)
                    {
                        var calendar = await this.context.DateTimeLocation
                            //.Include(x=>x.Event)
                            //.Include(x=>x.Room)
                            .Where(x => x.EventId.Equals(item.EventId) &&x.Status == 1)
                            .Select(x=>new DateTimeLocation
                            {
                                EventId= x.EventId,
                                RoomId= x.RoomId,
                                Date = x.Date,
                                //Event = new Event
                                //{
                                //    EventId = x.Event.EventId,
                                //    EventType = x.Event.EventType,
                                //    OrganizedPerson = x.Event.OrganizedPerson,
                                //},
                                //Room = new RoomLocation
                                //{
                                //    RoomId=x.Room.RoomId,
                                //    RoomName = x.Room.RoomName,
                                //    RoomDescription= x.Room.RoomDescription,
                                //    RoomImage= x.Room.RoomImage,
                                //    Capacity= x.Room.Capacity,
                                //    Parking= x.Room.Parking
                                //}
                            }).FirstOrDefaultAsync();
                        if(calendar!= null)
                        {
                            result.Add(calendar);
                        }
                        
                    }
                    
                    return result;
                }
                
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DateTimeLocation>> GetAllDateTimeLocation()
        {
            try
            {
                var check = await this.context.DateTimeLocation.Where(x=>x.Status ==1)
                    .Select(x => new DateTimeLocation
                    {
                        EventId = x.EventId,
                        RoomId = x.RoomId,
                        Date = x.Date,
                        Status = x.Status,
                        Event = new Event
                        {
                            EventId = x.Event.EventId,
                            EventType = x.Event.EventType,
                            OrganizedPerson = x.Event.OrganizedPerson,
                        },
                        Room = new RoomLocation
                        {
                            RoomId = x.Room.RoomId,
                            RoomName = x.Room.RoomName,
                            RoomDescription = x.Room.RoomDescription,
                            RoomImage = x.Room.RoomImage,
                            Capacity = x.Room.Capacity,
                            Parking = x.Room.Parking
                        }
                    })
                    .ToListAsync();
                if(check == null)
                {
                    return null;
                }
                else
                {
                    return check;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
