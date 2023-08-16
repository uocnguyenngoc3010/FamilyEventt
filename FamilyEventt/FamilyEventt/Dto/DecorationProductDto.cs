using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class DecorationProductDto
    {
        
        public string DecorationId { get; set; }
        
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public  DecorationDto Decoration { get; set; }
        public  ProductDto Product { get; set; }
    }
}
