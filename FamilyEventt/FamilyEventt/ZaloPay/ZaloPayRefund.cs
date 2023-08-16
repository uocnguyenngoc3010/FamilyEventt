namespace FamilyEventt.ZaloPay
{
    public class ZaloPayRefund
    {
        public int return_code { get; set; }
        public string return_message { get; set; }
        public int sub_return_code { get; set; }
        public string return_code_message { get; set; }
        public long refund_id { get; set; }
    }
}
