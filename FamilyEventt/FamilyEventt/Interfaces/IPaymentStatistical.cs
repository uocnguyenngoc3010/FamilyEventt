using FamilyEventt.Dto;

namespace FamilyEventt.Interfaces
{
    public interface IPaymentStatistical
    {
        Task<List<PaymentRespone>> GetAll();
        Task<List<PaymentRespone>> GetPaymentByEventID(string eventid);
        Task<List<PaymentRespone>> GetPaymentByEventBooker(string eventbookerId);
        Task<List<StatisticalRespone>> GetResponeDataDate(DateTime start, DateTime end, int type);
        Task<Statisticalv2dto> GetPaymentByEventIDnew(string eventid);
    }
}
