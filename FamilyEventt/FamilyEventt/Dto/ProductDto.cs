using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class ProductDto
    {
        
        public string ProductId { get; set; }
        [Required]
        public string DecorationProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public string ProductDetails { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductSupplier { get; set; }
        public bool Status { get; set; }

        // public virtual ICollection<DecorationProduct> DecorationProduct { get; set; }
    }
}
