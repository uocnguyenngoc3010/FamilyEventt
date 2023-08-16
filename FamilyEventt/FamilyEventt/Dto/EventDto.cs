using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class EventDto
    {
        
        public string EventId { get; set; }
        
        public string ScriptId { get; set; }
        
        public string DecorationId { get; set; }
        
        public string EventTypeId { get; set; }
        
        public string MenuId { get; set; }
       
        public string EntertainmentId { get; set; }
       
        public string EventBookerId { get; set; }
        [Required]
        public string OrganizedPerson { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool Status { get; set; }

        public  DecorationDto Decoration { get; set; }
        public EntertainmentDto Entertainment { get; set; }
        public EventBookerDto EventBooker { get; set; }
        public EventTypeDto EventType { get; set; }
        public MenuDto Menu { get; set; }
        public ScriptDto Script { get; set; }
        public  List<DateTimeLocationDto> DateTimeLocation { get; set; }
        public  List<PaymentDto> Payment { get; set; }
    }
}
