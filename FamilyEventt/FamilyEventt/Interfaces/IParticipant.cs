using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IParticipant
    {
        Task<List<Participant>> GetAllParticipant();
        Task<bool> UpdateParticipant(ParticipantDto participant);
        Task<bool> InsertParticipant(ParticipantDto participant);
        Task<List<Participant>> GetParticipantsByEvent(string ID);
    }
}
