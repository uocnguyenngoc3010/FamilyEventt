using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class ScriptDto
    {
        
        public string Id { get; set; }
        [Required]
        public string ScriptName { get; set; }
        [Required]
        public string ScriptContent { get; set; }
        [Required]
        public bool Status { get; set; }
       

        //public virtual EventType EventTypeNavigation { get; set; }
        //public virtual ICollection<Event> Event { get; set; }
    }
}
