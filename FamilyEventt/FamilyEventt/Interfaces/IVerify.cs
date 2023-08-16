using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IVerify
    {
        Task<bool> InsertVerifyCodeEvent(string EventId);
        Task<Verify> GetVerifyCodeEvent(string EventId);
        Task<List<Verify>> GetAllVerify();
        Task<bool> InsertVerifyCodeData(string EventId);
    }
}
