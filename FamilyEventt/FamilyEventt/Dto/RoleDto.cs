using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class RoleDto
    {
        
        public string RoleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

       // public virtual ICollection<Staff> Staff { get; set; }
    }
}
