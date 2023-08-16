using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class FoodDto
    {
        public string FoodId { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public string Dish { get; set; }
        [Required]
        public decimal FoodPrice { get; set; }
        /*[Required]
        public int? FoodQuantity { get; set; }*/
        [Required]
        public string FoodDescription { get; set; }
        [Required]
        public string FoodIngredient { get; set; }
        [Required]
        public string FoodOrigin { get; set; }
        [Required]
        public string CookingRecipe { get; set; }
        [Required]
        public string FoodImage { get; set; }
        
        public string FoodTypeId { get; set; }
        [Required]
        public bool Status { get; set; }

        //public  FoodTypeDto FoodType { get; set; }
        // public  List<MenuProductDto> MenuProductDto { get; set; }
    }
}
