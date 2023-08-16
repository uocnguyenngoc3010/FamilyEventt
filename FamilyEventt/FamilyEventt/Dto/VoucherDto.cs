namespace FamilyEventt.Dto
{
    public class VoucherDto
    {
        public string VoucherId { get; set; }
        public string VoucherName { get; set; }
        public int VoucherDiscount { get; set; }
        public string VoucherImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        //public string EventId { get; set; }
    }
}
