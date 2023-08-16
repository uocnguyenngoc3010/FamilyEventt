using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class DrinkDto
    {
       
        public string DrinkId { get; set; }
        [Required]
        public string DrinkName { get; set; }
        [Required]
        public int DrinkQuantity { get; set; }
        [Required]
        public decimal DrinkPrice { get; set; }
        [Required]
        public string DrinkDetail { get; set; }
        [Required]
        public string DrinkImage { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
