using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class EntertainmentProductDto
    {
        
        public string EntertainmentId { get; set; }
       
        public string ProductId { get; set; }
        public string? ShowId { get; set; }
        public string? GameId { get; set; }
        public decimal? EntertainmentProductPrice { get; set; }
        public int? Quantity { get; set; }

        //public EntertainmentDto Entertainment { get; set; }
        //public  GameServicesDto Product { get; set; }
        //public  ShowServiceDto ProductNavigation { get; set; }
    }
}
