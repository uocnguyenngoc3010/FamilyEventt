using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IVoucher
    {
        Task<Voucher> Insert(VoucherDto newVoucher);
        Task<Voucher> Update(VoucherDto newVoucher);
        Task<List<Voucher>> GetAllVoucher();
        Task<List<Voucher>> SearchByName(string name);
        Task<Voucher> SearchByID(string ID);
        Task<bool> Disable();
        Task<bool> Delete(string id);
        Task<Event> AddVoucher(string eventid, string voucherid);
    }
}
