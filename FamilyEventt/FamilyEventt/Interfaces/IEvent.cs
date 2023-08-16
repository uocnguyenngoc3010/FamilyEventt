using FamilyEventt.Dto;
using FamilyEventt.Dto.ResponeEventForExport;
using FamilyEventt.Models;
using System.Threading.Tasks;

namespace FamilyEventt.Interfaces
{
    public interface IEvent
    {
        Task<List<Event>> GetAllEvents();
        Task<bool> UpdateEvent(EventDto uptEventDto);
        Task<bool> DeleteEvent(string dltEventId);
        Task<bool> InsertEvent(EventDto newEvent);
        Task<List<Event>> GetEventByEventBookerID(string EventBookerID);
        Task<Event> GetEventByID(string id);
        Task<Script> GetScriptByEvent(string Eventid);
        Task<List<Product>> GetProductDecorationByEvent(string Eventid);
        Task<List<FoodDto>> GetMenuByEvent(string Eventid);
        Task<List<EntertainmentProduct>> GetEntertainmentByEvent(string Eventid);
        Task<List<Event>> GetEventByDay(string eventbooker, DateTime minDate, DateTime maxDate);
        Task<List<Event>> GetEventByDayForAdmin(DateTime minDate, DateTime maxDate);
        Task<bool> disableEvent();
        Task<string> InsertDataMobile(EventRequestDto dto);
        Task<ResponeEventAll> ExportData(string eventid);
        Task<List<ResponeEventAll>> ExportDataMobile(string eventbooker);
        Task<string> UpdateDataMobile(UpdateEventMobile dto);
        Task<bool> UpdateEventAll();
    }
}
