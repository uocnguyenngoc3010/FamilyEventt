using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto.MenuDTOFE
{
    public class FoodRequest
    {
        public string FoodId { get; set; }
        public int Quantity { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodTypeId { get; set; }
    }
}
