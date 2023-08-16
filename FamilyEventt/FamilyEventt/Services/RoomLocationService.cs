using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class RoomLocationService : IRoomLocation
    {
        protected readonly FamilyEventContext context;
        public RoomLocationService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteRoom(string id)
        {
            try
            {
                var room = await this.context.RoomLocation.Where(x =>x.Status && x.RoomId == id).FirstOrDefaultAsync();
                if (room != null)
                {
                    room.Status = false;
                    this.context.RoomLocation.Update(room);
                    await this.context.SaveChangesAsync();
                    await this.context.DateTimeLocation.LoadAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoomLocation>> GetAllRoom()
        {
            try
            {
                var data = await this.context.RoomLocation
                    .Where(x => x.Status)
                    .OrderBy(x => x.RoomName)
                    .Select(x => new RoomLocation
                    {
                        RoomId = x.RoomId,
                        RoomName = x.RoomName,
                        Parking= x.Parking,
                        Capacity= x.Capacity,
                        RoomImage= x.RoomImage,
                        RoomDescription= x.RoomDescription,
                        Status= x.Status,
                    })
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }   
        }

        public async Task<RoomLocation> GetRoomById(string ID)
        {
            try
            {
                var room = await this.context.RoomLocation.Where(x => x.RoomId == ID && x.Status).FirstOrDefaultAsync();
                if (room == null)
                {
                    return null;
                }
                else
                {
                    return room;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> InsertRoom(RoomLocationDto room)
        {
            try
            {
                var _room = new RoomLocation();
                _room.RoomId = "RId" + Guid.NewGuid().ToString().Substring(0, 20);
                _room.Status = true;
                _room.RoomName = room.RoomName;
                _room.Parking = room.Parking;
                _room.Capacity = room.Capacity;
                _room.RoomDescription = room.RoomDescription;
                _room.RoomImage = room.RoomImage;


                await this.context.RoomLocation.AddAsync(_room);
                this.context.SaveChangesAsync();
                //await this.context.DateTimeLocation.LoadAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRoom(RoomLocationDto room)
        {
            try
            {
                var _room = await this.context.RoomLocation.Where(y => y.RoomId == room.RoomId).FirstOrDefaultAsync();
                if (room == null) { return false; }
                else
                {
                    _room.Status = room.Status;
                    _room.RoomName = room.RoomName;
                    _room.Parking = room.Parking;
                    _room.Capacity = room.Capacity;
                    _room.RoomDescription = room.RoomDescription;
                    _room.RoomImage = room.RoomImage;

                    this.context.RoomLocation.Update(_room);
                    this.context.SaveChangesAsync();
                    await this.context.DateTimeLocation.LoadAsync();
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
