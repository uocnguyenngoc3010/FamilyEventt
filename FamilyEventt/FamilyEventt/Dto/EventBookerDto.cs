using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
     /*
    */
    public class EventBookerDto
    {
        //[Required(ErrorMessage = "not information")]
        public string EventBookerId { get; set; }
        [StringLength(maximumLength: 50,
                  MinimumLength = 2,
                  ErrorMessage = "Event Booker name's length must be between 2-50 characters")]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool? Gender { get; set; }
        [Required]
        public DateTime? RegisterDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool Status { get; set; }
        public DateOnly? BirthDay { get; set; }

        //public virtual Account EventBookerNavigation { get; set; }

        /*public virtual ICollection<ChatMessage> ChatMessage { get; set; }
        public virtual ICollection<EventOrder> EventOrder { get; set; }*/
    }
}
