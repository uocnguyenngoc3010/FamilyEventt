using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IEntertainment
    {
        Task<List<Entertainment>> GetAllEntertainments();
        Task<Entertainment> GetByIdEntertainments(string? EntertainmentId);
        Task<bool> UpdateEntertainment(EntertainmentDto upEntertainment);
        Task<bool> DeleteEntertainment(string[] EntertainmentId);
        Task<Entertainment> InserEntertainment(EntertainmentDto entertainment);
    }
}
