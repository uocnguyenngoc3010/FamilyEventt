namespace FamilyEventt.Dto
{
    public class PaymentRespone
    {
        public string? eventbooker { get; set; }
        public decimal? total { get; set; }
        public string? eventid { get; set; }
        public string? paymentid { get; set; }
        public DateTime? date { get; set; }
        public decimal? amount { get; set; }
        public string? note { get; set; }
    }
}
