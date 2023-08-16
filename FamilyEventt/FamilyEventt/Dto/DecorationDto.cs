using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class DecorationDto
    {
       
        public string DecorationId { get; set; }
        [Required]
        public string DecorationName { get; set; }
        [Required]
        public decimal DecorationPrice { get; set; }
        [Required]
        public string DecorationImage { get; set; }

        //public virtual ICollection<DecorationProduct> DecorationProduct { get; set; }
        //public virtual ICollection<Event> Event { get; set; }
    }
}
