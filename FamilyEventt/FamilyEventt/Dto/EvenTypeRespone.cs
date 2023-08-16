using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class EvenTypeRespone
    {
        public string EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeImage { get; set; }
        public string EventTypeDescription { get; set; }
        public DateTime Date { get; set; }
        public string? people { get; set; }
    }
}
