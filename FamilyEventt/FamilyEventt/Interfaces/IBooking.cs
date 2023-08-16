using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IBooking
    {
        Task<List<DateTimeLocation>> CheckUsedRoomByDay(DateTime date);
        Task<bool> BookingRoom(string eventID, string roomID, DateTime date);
        Task<List<RoomLocation>> CheckEmptyRoomByDay(DateTime date);
        Task<bool> DeleteBooking(DateTimeLocationDto dto);
        Task<List<DateTimeLocation>> GetDateTimeLocationByEventBooker(string id);
        Task<List<DateTimeLocation>> GetAllDateTimeLocation();
    }
}
