using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class EntertainmentDto
    {
        public string EntertainmentId { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public decimal EntertainmentTotal { get; set; }

        //public virtual Event Event { get; set; }
        // public virtual ICollection<EntertainmentProduct> EntertainmentProduct { get; set; }
    }
}
