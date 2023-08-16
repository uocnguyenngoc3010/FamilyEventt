using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class DecoProductUpdate
    {
        public string DecorationId { get; set; }
        public string OldProductId { get; set; }
        public string newProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
