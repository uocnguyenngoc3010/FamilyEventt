using FamilyEventt.Models;

namespace FamilyEventt.Dto
{
    public class FamilyDto
    {
        public int Id { get; set; }
        public string EventBookerId { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberPhone { get; set; }
        public bool Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Relation { get; set; }
        public bool Status { get; set; }

        public EventBookerDto EventBooker { get; set; }
    }
}
