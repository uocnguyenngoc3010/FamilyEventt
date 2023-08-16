using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FamilyEventt.Services
{
    public class NotificationService : INotification
    {
        protected readonly FamilyEventContext context;

        public NotificationService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<Notification> CreateNotification(string? eventID, int? type)
        {
            var result = new Notification();
            try
            {
                var checkEvent = await this.context.Event.Where(e => e.Status).Select(x=> new Event
                {
                    StartDate= x.StartDate,
                    EndDate= x.EndDate,
                    DecorationId= x.DecorationId,
                    TotalPrice= x.TotalPrice,
                    EntertainmentId= x.EntertainmentId,
                    EventTypeId= x.EventTypeId,
                    EventId = x.EventId,
                    EventBookerId= x.EventBookerId
                }).ToListAsync();
                result.EventId = eventID;
                result.Status = true;
                result.Date = DateTime.Now;
                result.Type = Convert.ToInt32(type).ToString();
                
                switch (type)
                {
                    case 0:
                        result.NotificationContent = "tạo sự kiện thành công #" +eventID+ " " + DateTime.Now ;
                        await this.context.Notification.AddAsync(result);
                        this.context.SaveChanges();
                        return result;
                        break;
                    case 1:
                        result.NotificationContent = "thanh toán thành công #" +eventID + " " + DateTime.Now;
                        await this.context.Notification.AddAsync(result);
                        this.context.SaveChanges();

                        return result;
                        break;
                    case 2:
                        result.NotificationContent = "hủy đặt lịch thành công #" +eventID + " " + result.Date;
                        await this.context.Notification.AddAsync(result);
                        this.context.SaveChanges();
                        return result;
                        break;
                    case 3:
                        result.NotificationContent = "hoàn tiền đặt lịch cho sự kiện #" + eventID + " " + result.Date +" thành công";
                        await this.context.Notification.AddAsync(result);
                        this.context.SaveChanges();
                        return result;
                        break;
                    case 4:
                        foreach(var items in checkEvent)
                        {
                            result.EventId = eventID;
                            result.Status = true;
                            result.Date = DateTime.Now;
                            result.Type = Convert.ToInt32(type).ToString();

                            DateTime min = Convert.ToDateTime(items.StartDate);
                            DateTime max = Convert.ToDateTime(DateTime.Now);
                            TimeSpan Time = max - min;
                            int check = Time.Days;

                            if (check < 7)
                            {
                                if (items.EndDate < DateTime.Now)
                                {
                                    result.NotificationContent = "vui lòng thanh toán toàn bộ sự kiện trước #" + items.EndDate;
                                    await this.context.Notification.AddAsync(result);
                                    this.context.SaveChanges();
                                }
                            }
                            
                        }
                        return result;
                        break;
                    default:
                        return result;
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Notification> CreateNotificationForFamily(string eventbooker, int type)
        {
            var result = new Notification();
            try
            {
                var checkEvent = await this.context.Event.Where(e => e.EventBookerId.Equals(eventbooker) && e.Status ).Select(x => new Event
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DecorationId = x.DecorationId,
                    TotalPrice = x.TotalPrice,
                    EntertainmentId = x.EntertainmentId,
                    EventTypeId = x.EventTypeId,
                    EventId = x.EventId,
                    EventBookerId = x.EventBookerId
                }).ToListAsync();
                var family = await this.context.Family.Where(x=>x.EventBookerId.Equals(eventbooker)).ToListAsync();

                switch (type)
                {
                    case 0:
                        if(family.Count > 0)
                        {
                            foreach (var item in checkEvent)
                            {
                                result.EventId = item.EventId;
                                result.Status = true;
                                result.Date = DateTime.Now;
                                result.Type = Convert.ToInt32(type).ToString();
                                result.NotificationContent = "sắp tới có sự kiện #" + item.EventId + " " + item.EndDate + " cho #" + item.OrganizedPerson;
                                await this.context.Notification.AddAsync(result);
                                this.context.SaveChanges();
                            }
                        }
                        return result;
                        break;
                    case 1:
                        if (family.Count > 0)
                        {
                            foreach (var item in checkEvent)
                            {
                                result.EventId = item.EventId;
                                result.Status = true;
                                result.Date = DateTime.Now;
                                result.Type = Convert.ToInt32(type).ToString();
                                result.NotificationContent = "bạn được mời tới sự kiện #" + item.EventId + " " + item.EndDate + " cho #" + item.OrganizedPerson;
                                await this.context.Notification.AddAsync(result);
                                this.context.SaveChanges();
                            }
                        }
                        return result;
                        break;

                    default:
                        return result;
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Notification>> GetNotificationsByEvent(string eventID)
        {
            try
            {
                var result = await this.context.Notification.Where(x => x.EventId.Equals(eventID) && x.Status).ToListAsync();
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<NotificationRespone>> getNotificationVerify(string? phone, string? eventbooker)
        {
            try
            {
                var result = new List<NotificationRespone>();
                var check = await this.context.Verify.ToListAsync();
                //string checkphone;
                foreach (var item in check)
                {
                    var respone = new NotificationRespone();
                    string[] checkphone = item.VerifyCode.Split("#");
                    if (checkphone[2].ToString().Equals(phone) || checkphone[2].ToString().Equals(eventbooker))
                    {
                        respone.VerifyCode = item.VerifyCode;
                        var notification = await this.context.Notification.Where(x => x.EventId.Equals(checkphone[1]) &&x.Type == "1" ).FirstOrDefaultAsync();
                        respone.NotificationContent = notification.NotificationContent;
                        result.Add(respone);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
