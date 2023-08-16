using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class ChatMessageDto
    {
        
        public string ChatId { get; set; }
       
        public string EventBookerId { get; set; }
        
        public string? StaffId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Status { get; set; }

        // public virtual EventBooker EventBooker { get; set; }
        // public virtual Staff Staff { get; set; }
    }
}
