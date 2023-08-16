namespace FamilyEventt.Dto
{
    public class Statisticalv2dto
    {
        public string? eventid { get; set; }
        public string? eventtype { get; set; }
        public decimal? total { get; set; }
        public int? count { get; set; }
        public string? note { get; set; }
        public List<PaymentRespone>? payments { get; set; }
    } 
}
