using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class GameServicesDto
    {
        
        public string GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public decimal GameServicePrice { get; set; }
        [Required]
        public string GameDetails { get; set; }
        [Required]
        public string GameRules { get; set; }
        [Required]
        public string GameReward { get; set; }
        [Required]
        public string Supplies { get; set; }
        [Required]
        public string GameImage { get; set; }
        [Required]
        public bool Status { get; set; }


        //public virtual ICollection<EntertainmentProduct> EntertainmentProduct { get; set; }
    }
}
