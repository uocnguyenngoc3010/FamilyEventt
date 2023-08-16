using FamilyEventt.Dto;
using FamilyEventt.Models;


namespace FamilyEventt.Interfaces
{
    public interface IRoomLocation
    {
        Task<List<RoomLocation>> GetAllRoom();
        Task<bool> UpdateRoom(RoomLocationDto room);
        Task<bool> InsertRoom(RoomLocationDto room);
        Task<bool> DeleteRoom(string id);
        Task<RoomLocation> GetRoomById(string ID);
        
    }
}
