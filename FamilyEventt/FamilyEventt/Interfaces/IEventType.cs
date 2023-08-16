using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IEventType
    {
        Task<List<EventType>> GetAllEvents();

        Task<bool> UpdateEventType(EventTypeDto uptEventDto);
        Task<bool> InsertEventType(EventTypeDto newEvent);
        Task<List<EventTypeDto>> FilterEventTypeByManyOption(string? name, string? id);
        //Task<List<EventType>> SearchByNameEventType(string Name);
        Task<List<EvenTypeRespone>> GetEventTypeByDate(DateTime date, string eventbooker);
    }
}
