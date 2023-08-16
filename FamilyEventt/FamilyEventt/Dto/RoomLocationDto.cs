using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class RoomLocationDto
    {
        
        public string RoomId { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public string Parking { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string RoomImage { get; set; }
        [Required]
        public string RoomDescription { get; set; }
        
        public bool Status { get; set; }
    }
}
