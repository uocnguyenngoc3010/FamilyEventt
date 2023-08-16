using FamilyEventt.Models;

namespace FamilyEventt.Dto
{
    public class EventRequestDto
    {
        public string eventbookerid { get; set; } 
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string EventTypeId { get; set; }
        public string MenuName { get; set; }
        public string decorationName { get; set; }
        public List<gameMobile> games { get; set; }
        public List<showMobile> shows { get; set; }
        public List<foodMobile> foods { get; set; }
        public List<decorationMobile> decorations { get; set; }
        public virtual roomMobile room { get; set; }
        public string scriptId { get; set; }
        public string OrganizedPeople { get; set; }
        //public string contract { get; set; }
        //public string note { get; set; }
        public bool status { get; set; }
        public int people { get; set; }
    }
}
