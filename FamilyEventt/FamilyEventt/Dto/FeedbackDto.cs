using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class FeedbackDto
    {
        public int? id { get; set; }
        public string? EventBookerId { get; set; }
        
        public string? EventId { get; set; }
        public int? Vote { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; }
        public string? Reply { get; set; }
        public bool Status { get; set; }
        public virtual EventDto? eventt { get; set; }
        public virtual EventBookerDto? EventBooker { get; set; }
    }
}
