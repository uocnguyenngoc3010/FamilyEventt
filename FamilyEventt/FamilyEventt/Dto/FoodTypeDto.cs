using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class FoodTypeDto
    {
        
        public string FoodTypeId { get; set; }
        [Required]
        public string FoodTypeName { get; set; }
        [Required]
        public string FoodTypeDetail { get; set; }

        //public virtual ICollection<Food> Food { get; set; }
    }
}
