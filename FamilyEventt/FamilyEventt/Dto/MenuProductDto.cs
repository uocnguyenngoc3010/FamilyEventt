using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class MenuProductDto
    {
        
        public string MenuId { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        public int Quatity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Type { get; set; }

        public DrinkDto Menu { get; set; }
        public  MenuDto Menu1 { get; set; }
        public  FoodDto MenuNavigation { get; set; }

        //public DrinkDto Menu { get; set; }
        //public  MenuDto MenuNavigation { get; set; }
        //public  FoodDto Product { get; set; }
    }
}
