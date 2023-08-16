using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Newtonsoft.Json;

namespace FamilyEventt.ZaloPay
{
    public class ZaloPayService
    {
        private readonly EventService _service;
        public ZaloPayService(EventService service)
        {
            this._service = service;
        }

        public const string create_order_url = "https://sb-openapi.zalopay.vn/v2/create";
        public const string app_id = "2554";
        public const string key1 = "sdngKKJmqEMzvh5QQcdD2A9XBSKUNaYn";
        public const string Key2 = "trMrHtvjo6myautxDUiAcYsVtaeQ8nhf";
        public const string RefundUrl = "https://sb-openapi.zalopay.vn/v2/refund";
        public const string GetStatusUrl = "https://sb-openapi.zalopay.vn/v2/query";
        public async Task<ZaloRespone> CreateOrder(string id)
        {
            var respone = new ZaloRespone();
            try
            {
                Random rnd = new Random();
                var embed_data = new Dictionary<string, string>();
                var items = new[] { new { } };
                var param = new Dictionary<string, string>();
                var app_trans_id = rnd.Next(1000000);
                Event chckevent = _service.GetEventByID1(id);

                var amount = chckevent.TotalPrice;

                param.Add("app_id", "id");
                param.Add("app_user", "user123");
                param.Add("app_time", DateTime.Now.ToString());
                param.Add("amount", amount.ToString().Substring(0, amount.ToString().Length - 5));
                param.Add("app_trans_id", DateTime.Now.ToString("yyMMdd") + "_" + app_trans_id); // mã giao dich có định dạng yyMMdd_xxxx
                param.Add("embed_data", JsonConvert.SerializeObject(embed_data));
                param.Add("item", JsonConvert.SerializeObject(items));
                param.Add("description", "EventFamily - Thanh toán sự kiện #" + id);
                param.Add("bank_code", "zalopayapp");

                var data = app_id + "|" + param["app_trans_id"] + "|" + param["app_user"] + "|" + param["amount"] + "|"
                + param["app_time"] + "|" + param["embed_data"] + "|" + param["item"];
                param.Add("mac", HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key1, data));

                var result = await HttpHelper.PostFormAsync(create_order_url, param);

                var resultPost = new ZaloRespone
                {
                    ReturnCode = Convert.ToInt32(result["return_code"]),
                    ReturnMessage = result["return_message"].ToString(),
                    SubReturnCode = Convert.ToInt32(result["sub_return_code"]),
                    SubReturnMessage = result["sub_return_message"].ToString(),
                    OrderUrl = result["order_url"].ToString(),
                    ZpTransToken = result["zp_trans_token"].ToString(),
                    ZpTransId = param["app_trans_id"].Trim()
                };

                respone = resultPost;
                return respone;
            }
            catch (Exception ex)
            {
                return respone;
            }
        }
       
    }
}
