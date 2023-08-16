using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IEventBooker
    {
        Task<List<EventBooker>> GetAllEventBookers();
        Task<EventBooker> GetByIdEventbooker(string? Id);
        Task<List<EventBooker>> SearchByNameEventBooker(string name);
        Task<EventBooker> UpdateEventBooker(EventBookerDto upEventBooker);
        Task<bool> DeleteEventBooker(string id);
        Task<bool> InsertEventBooker(EventBookerDto eventBooker);
        Task<EventBooker> GetEventBookerByPhone(string phone);
        Task<bool> InsertEventBookerfield(string Phone, string fullname, string addr, bool gender);
    }
}
