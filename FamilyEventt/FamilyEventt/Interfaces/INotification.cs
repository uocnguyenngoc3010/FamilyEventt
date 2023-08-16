using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface INotification
    {
        Task<Notification> CreateNotification(string? eventID, int? type);
        Task<List<Notification>> GetNotificationsByEvent(string eventID);
        Task<Notification> CreateNotificationForFamily(string eventbooker, int type);
    }
}
