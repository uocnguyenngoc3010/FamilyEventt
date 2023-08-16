using FamilyEventt.Models;

namespace FamilyEventt.Dto
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string EventId { get; set; }
        public string? NotificationContent { get; set; }
        public DateTime? Date { get; set; }
        public string? Type { get; set; }
        public bool Status { get; set; }

       // public virtual Event Event { get; set; }
    }
}
