using FamilyEventt.Models;

namespace FamilyEventt.Dto.ResponeEventForExport
{
    public class ResponeEventAll
    {
        public string? EventId { get; set; }
        public string? ScriptId { get; set; }
        public string? DecorationId { get; set; }
        public string? MenuId { get; set; }
        public string? EntertainmentId { get; set; }
        public string? OrganizedPerson { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public string? MenuName { get; set; }
        public int? QuantityTable { get; set; }
        public virtual List<FoodRespone>? foods { get; set; }
        public virtual List<ProductRespone>? products { get; set; }
        public virtual List<GameRespone>? gameServices { get; set; }
        public virtual List<ShowRespone>? showServices { get; set; }
        public virtual BookerRespone? EventBooker { get; set; }
        public virtual DateTimeRespone? DateTimeRespone { get; set; }
        public virtual VerifyRespone? VerifyRespone { get; set; }
        public virtual ScriptRespone? ScriptRespone { get; set; }
        public virtual EventTypeRespone? evt { get; set; }
    }
}
