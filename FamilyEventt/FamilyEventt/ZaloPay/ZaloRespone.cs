﻿namespace FamilyEventt.ZaloPay
{
    public class ZaloRespone
    {
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public int SubReturnCode { get; set; }
        public string SubReturnMessage { get; set; }
        public string OrderUrl { get; set; }
        public string ZpTransToken { get; set; }
        public string ZpTransId { get; set; }
    }
}
