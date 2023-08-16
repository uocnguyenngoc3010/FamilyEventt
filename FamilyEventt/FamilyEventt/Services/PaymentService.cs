using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FamilyEventt.Services
{
    public class PaymentService : IPaymentStatistical
    {
        protected readonly FamilyEventContext context;
        public PaymentService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<List<PaymentRespone>> GetAll()
        {
            try
            {
                var result = new List<PaymentRespone>();
                var item = new PaymentRespone();
                var eve = await this.context.Event.ToListAsync();
                foreach (var e in eve)
                {
                    var payment = await this.context.Payment.Where(x => x.EventId.Equals(e.EventId)).ToListAsync();
                    foreach (var x in payment)
                    {
                        item.paymentid = x.PaymentId;
                        item.amount = x.Amount;
                        item.date = x.Date;
                        item.total = e.TotalPrice;
                        item.eventid = e.EventId;
                        item.eventbooker = e.EventBookerId;
                        if (item.total - item.amount <= 0)
                        {
                            item.note = "Đã thanh toán đầy đủ";
                        }
                        else if (item.total - item.amount > 0)
                        {
                            item.note = "Đã thanh toán " + item.amount + " # Chưa thanh toán " + (item.total - item.amount);
                        }
                        else
                        {
                            item.note = "not available";
                        }
                        result.Add(item);
                        item = new PaymentRespone();
                    }
                    item.eventbooker = e.EventBookerId;
                    item.total = e.TotalPrice;
                    item.eventid = e.EventId;
                    item.amount = 0;
                    item.note = "Chưa thanh toán";
                    result.Add(item);
                    item = new PaymentRespone();
                }
                return result;
            } catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PaymentRespone>> GetPaymentByEventID(string eventid)
        {
            try
            {
                var result = new List<PaymentRespone>();
                var item = new PaymentRespone();
                var payment = await this.context.Payment.Where(x => x.EventId.Equals(eventid)).ToListAsync();
                foreach (var x in payment)
                {
                    item.paymentid = x.PaymentId;
                    item.eventid = x.EventId;
                    item.amount = x.Amount;
                    item.date = x.Date;
                    var check = await this.context.Event.Where(b => b.EventId.Equals(x.EventId)).FirstOrDefaultAsync();
                    item.eventbooker = check.EventBookerId;
                    item.total = check.TotalPrice;
                    if (item.total - item.amount <= 0)
                    {
                        item.note = "Đã thanh toán đầy đủ";
                    }
                    else if (item.total - item.amount > 0)
                    {
                        item.note = "Đã thanh toán " + item.amount + " # Chưa thanh toán " + (item.total - item.amount);
                    }
                    else
                    {
                        item.note = "not available";
                    }
                    result.Add(item);
                    item = new PaymentRespone();
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Statisticalv2dto> GetPaymentByEventIDnew(string eventid)
        {
            try
            {
                var result = new Statisticalv2dto();
                decimal tmp = 0;
                result.count = 0;
                result.payments = new List<PaymentRespone>();
                var payment = await this.context.Payment.Where(x => x.EventId.Equals(eventid)).ToListAsync();
                var eventt = await this.context.Event.Where(x=>x.EventId.Equals(eventid))
                    .Select(x=> new Event
                    {
                        EventId = x.EventId,
                        TotalPrice= x.TotalPrice,
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName
                        },
                        EventBooker = new EventBooker
                        {
                            EventBookerId = x.EventBooker.EventBookerId,
                            Fullname = x.EventBooker.Fullname
                        }
                    })
                    .FirstOrDefaultAsync();
                foreach (var x in payment)
                {
                    result.count++;
                    tmp += x.Amount;
                    result.payments.Add(new PaymentRespone
                    {
                        eventbooker = eventt.EventBooker.Fullname,
                        amount = x.Amount,
                        date = x.Date,
                        paymentid = x.PaymentId,
                        eventid = x.EventId,
                        total = eventt.TotalPrice
                    });
                }
                result.total = eventt.TotalPrice;
                result.eventtype = eventt.EventType.EventTypeName;
                result.eventid = eventt.EventId;
                if((eventt.TotalPrice - tmp) > 0)
                {
                    result.note = "Đã thanh toán " + tmp + " # Chưa thanh toán " + (eventt.TotalPrice - tmp);
                }
                else
                {
                    result.note = "Tổng tiền: " + eventt.TotalPrice + " Đã thanh toán : " + tmp;
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PaymentRespone>> GetPaymentByEventBooker(string eventbookerId)
        {
            try
            {
                var result = new List<PaymentRespone>();
                var item = new PaymentRespone();
                var eve = await this.context.Event.Where(x=>x.EventBookerId.Equals(eventbookerId)).ToListAsync();
                foreach(var e in eve)
                {
                    var payment = await this.context.Payment.Where(x => x.EventId.Equals(e.EventId)).ToListAsync();
                    foreach (var x in payment)
                    {
                        item.paymentid = x.PaymentId;
                        item.eventid = x.EventId;
                        item.amount = x.Amount;
                        item.date = x.Date;
                        var check = await this.context.Event.Where(b => b.EventId.Equals(x.EventId)).FirstOrDefaultAsync();
                        item.eventbooker = check.EventBookerId;
                        item.total = check.TotalPrice;
                        if (item.total - item.amount <= 0)
                        {
                            item.note = "Đã thanh toán đầy đủ";
                        }
                        else if (item.total - item.amount > 0)
                        {
                            item.note = "Đã thanh toán " + item.amount + " # Chưa thanh toán " + (item.total - item.amount);
                        }
                        else
                        {
                            item.note = "not available";
                        }
                        result.Add(item);
                        item = new PaymentRespone();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<StatisticalRespone>> GetResponeDataDate(DateTime start, DateTime end,int type)
        {
            try
            {
                var list = new List<StatisticalRespone>();
                var item = new StatisticalRespone();
                decimal real = 0;
                decimal total =0;
                var check = await this.context.DateTimeLocation.Where(x=>x.Date <end && x.Date >start).ToListAsync();
                var eve = new List<Event>();
                foreach(var e in check)
                {
                    var checkev = await this.context.Event.Select(x=> new Event
                    {
                        EventId= x.EventId,
                        TotalPrice= x.TotalPrice,
                        EventType = new EventType
                        {
                            EventTypeId = x.EventType.EventTypeId,
                            EventTypeName = x.EventType.EventTypeName
                        }
                    }).Where(x => x.EventId.Equals(e.EventId)).FirstOrDefaultAsync();
                    eve.Add(checkev);
                }
                switch (type)
                {
                    case 0:
                        foreach (var e in eve)
                        {
                            var pay = await this.context.Payment.Where(x => x.EventId == e.EventId).ToListAsync();
                            foreach (var p in pay)
                            {
                                item.count++;
                                real += p.Amount;
                            }
                            //total += e.TotalPrice;
                            item.eventtype = e.EventType.EventTypeName;
                            item.total = e.TotalPrice;
                            item.realtotal = real;
                            item.eventid = e.EventId;
                            item.note = "Doanh thu ước tính " + item.total + "\n Doanh thu thực tế " + item.realtotal;
                            list.Add(item);
                            item = new StatisticalRespone();
                        }
                        break;
                    case 1:
                        int count =0;
                        foreach (var e in eve)
                        {
                            count++;
                            var pay = await this.context.Payment.Where(x => x.EventId == e.EventId).ToListAsync();
                            foreach (var p in pay)
                            {
                                real += p.Amount;
                            }
                            total += e.TotalPrice;
                        }
                        item.count = count;
                        item.total = total;
                        item.realtotal = real;
                        item.note = "Doanh thu ước tính " + item.total + "\n Doanh thu thực tế " + item.realtotal;
                        list.Add(item);
                        break;
                    default: 
                        break;
                }
               

                return list;
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}

    

