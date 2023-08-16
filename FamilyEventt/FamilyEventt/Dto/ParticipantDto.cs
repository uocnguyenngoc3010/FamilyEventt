using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class ParticipantDto
    {
        [Required]
        public double PhoneParticipant { get; set; }
        [Required]
        public string FullNameParticipant { get; set; }
        [Required]
        public string Relation { get; set; }
       
        public string EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
