using BCrypt.Net;
using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class FeedbackService : IFeedback
    {
        protected readonly FamilyEventContext context;
        public FeedbackService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<List<FeedbackDto>> GetFeedbackByEvent(string ID)
        {
            try
            {
                var feedback = await this.context.Feedback.Where(x => x.EventId == ID && x.Status)
                    .Select(x => new FeedbackDto
                    {
                        id= x.Id,
                        EventId = x.EventId,
                        Status = x.Status,
                        Date = x.Date,
                        EventBookerId = x.EventBookerId,
                        Message = x.Message,
                        Reply = x.Reply,
                        Vote = x.Vote
                    }).ToListAsync();
                if (feedback == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in feedback)
                    {
                        var check = await this.context.EventBooker.Where(x => x.EventBookerId.Equals(item.EventBookerId)).Select(x => new EventBooker
                        {
                            Fullname = x.Fullname,
                            EventBookerId = x.EventBookerId,
                            Address = x.Address,
                            DateOfBirth = x.DateOfBirth,
                            Gender = x.Gender,
                            Image = x.Image,
                            Email = x.Email,
                            Phone = x.Phone,
                            RegisterDate = x.RegisterDate,
                            Status = x.Status,
                        }).FirstOrDefaultAsync();
                        item.EventBooker = new EventBookerDto
                        {
                            EventBookerId = check.EventBookerId,
                            Fullname = check.Fullname,
                            Status = check.Status,
                            RegisterDate = check.RegisterDate,
                            Phone = check.Phone,
                            Email = check.Email,
                            Address = check.Address,
                            Image = check.Image,
                            Gender = check.Gender,
                            //DateOfBirth= check.RegisterDate,
                            DateOfBirth = check.DateOfBirth
                        };
                    }
                    return feedback;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FeedbackDto>> GetFeedbackByEventBooker(string ID)
        {
            try
            {
                var feedback = await this.context.Feedback.Where(x => x.EventBookerId == ID && x.Status).
                    Select(x=> new FeedbackDto
                    {
                        id= x.Id,
                        EventId = x.EventId,
                        Status = x.Status,
                        Date= x.Date,
                        EventBookerId = x.EventBookerId,
                        Message= x.Message,
                        Reply = x.Reply,
                        Vote = x.Vote
                    }).ToListAsync();
                if (feedback == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in feedback)
                    {
                        var check = await this.context.EventBooker.Where(x => x.EventBookerId.Equals(item.EventBookerId)).Select(x=> new EventBooker
                        {
                            Fullname = x.Fullname,
                            EventBookerId = x.EventBookerId,
                            Address= x.Address,
                            DateOfBirth= x.DateOfBirth,
                            Gender= x.Gender,
                            Image = x.Image,
                            Email= x.Email,
                            Phone= x.Phone,
                            RegisterDate = x.RegisterDate,
                            Status= x.Status,
                        }).FirstOrDefaultAsync();
                        item.EventBooker = new EventBookerDto{
                            EventBookerId = check.EventBookerId,
                            Fullname= check.Fullname,
                            Status= check.Status,
                            RegisterDate= check.RegisterDate,
                            Phone= check.Phone,
                            Email= check.Email,
                            Address= check.Address,
                            Image= check.Image,
                            Gender= check.Gender,
                            //DateOfBirth= check.RegisterDate,
                            DateOfBirth = check.DateOfBirth
                        };
                    }
                    return feedback;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FeedbackDto> InsertFeedback(FeedbackDto feedback)
        {
            try
            {
                var _feedback = new Feedback();
                _feedback.EventBookerId = feedback.EventBookerId;
                _feedback.EventId = feedback.EventId;
                _feedback.Status = feedback.Status;
                _feedback.Vote=feedback.Vote;
                _feedback.Date=DateTime.Now;
                _feedback.Message=feedback.Message;
                _feedback.Reply=feedback.Reply;
                await this.context.Feedback.AddAsync(_feedback);
                this.context.SaveChanges();
                await this.context.Event.LoadAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateFeedback(FeedbackDto feedback)
        {
            try
            {
                var _feedback = await this.context.Feedback.Where(x => x.Id.Equals(feedback.id) && x.Status).FirstOrDefaultAsync();
                if (_feedback == null) { return false; }
                else
                {
                    //_feedback.EventBookerId = feedback.EventBookerId;
                    //_feedback.EventId = feedback.EventId;
                    _feedback.Status = feedback.Status;
                    _feedback.Vote = feedback.Vote;
                    _feedback.Date = DateTime.Now;
                    _feedback.Message = feedback.Message;
                    _feedback.Reply = feedback.Reply;


                    this.context.Feedback.Update(_feedback);
                    this.context.SaveChangesAsync();
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
