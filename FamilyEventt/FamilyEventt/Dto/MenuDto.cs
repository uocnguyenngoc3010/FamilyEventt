using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class MenuDto
    {
        
        public string MenuId { get; set; }
        [Required]
        public string MenuName { get; set; }
        [Required]
        public decimal PriceTotal { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int? TableQuantity { get; set; }


        //public List<EventDto> Event { get; set; }
        //public List<MenuProductDto> MenuProduct { get; set; }
    }
}
