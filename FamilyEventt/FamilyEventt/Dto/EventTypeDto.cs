using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class EventTypeDto
    {
        
        public string EventTypeId { get; set; }
        [Required]
        public string EventTypeName { get; set; }
        [Required]
        public string EventTypeImage { get; set; }
        
        public string EventTypeDescription { get; set; }

        //public List<EventTypeDto> Event { get; set; }
    }
}
