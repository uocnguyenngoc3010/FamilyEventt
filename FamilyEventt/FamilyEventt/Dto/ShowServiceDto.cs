using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class ShowServiceDto
    {
        public string? ShowId { get; set; }
        [Required]
        public decimal ShowPrice { get; set; }
        [Required]
        public string ShowServiceName { get; set; }
       
        [Required]
        public string Light { get; set; }
        [Required]
        public string Sound { get; set; }
        [Required]
        public string Singer { get; set; }
        [Required]
        public string ShowDescription { get; set; }
        [Required]
        
        public string ShowImage { get; set; }
        [Required]
        public bool Status { get; set; }

        //public  List<EntertainmentProductDto> EntertainmentProduct { get; set; }
    }
}
