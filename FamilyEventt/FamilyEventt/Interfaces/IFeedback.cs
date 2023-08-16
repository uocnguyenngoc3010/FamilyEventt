using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IFeedback
    {
        Task<bool> UpdateFeedback(FeedbackDto feedback);
        Task<FeedbackDto> InsertFeedback(FeedbackDto feedback);
        Task<List<FeedbackDto>> GetFeedbackByEvent(string ID);
        Task<List<FeedbackDto>> GetFeedbackByEventBooker(string ID);
    }
}
