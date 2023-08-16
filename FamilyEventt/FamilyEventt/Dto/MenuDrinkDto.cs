using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class MenuDrinkDto
    {
        
        public string MenuId { get; set; }
        
        public string DrinkId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
       // public virtual Drink Drink { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
