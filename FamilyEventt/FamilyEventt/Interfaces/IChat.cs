using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IChat
    {
        Task<bool> InsertMessage(ChatMessageDto chatMessage);
        Task<bool> DeleteMessage(string chatMessage);
        Task<List<ChatMessage>> SearchByEventBooker(string ID);
    }
}
