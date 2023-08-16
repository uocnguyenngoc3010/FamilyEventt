using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class VerifyService : IVerify
    {
        protected readonly FamilyEventContext context;

        public VerifyService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<List<Verify>> GetAllVerify()
        {
            try
            {

                List<Verify> verify = await this.context.Verify.ToListAsync();
                if (verify != null)
                {
                    return verify;
                }
                return null;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Verify> GetVerifyCodeEvent(string EventId)
        {
            try
            {
                Verify verify = await this.context.Verify.Where(x=>x.EventId.Equals(EventId)).FirstOrDefaultAsync();
                if (verify != null)
                {
                    return verify;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> InsertVerifyCodeEvent(string EventId)
        {
            try
            {
                Event check = await this.context.Event.Where(x=>x.EventId.Equals(EventId)).FirstOrDefaultAsync();
                Verify verify = new Verify();
                if (check != null)
                {
                    verify.EventId = check.EventId;
                    verify.VerifyCode = check.EventId.ToString() + check.EventBookerId.ToString();
                    await this.context.AddAsync(verify);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> InsertVerifyCodeData(string EventId)
        {
            try
            {
                var check = await this.context.Event.Where(x => x.EventId.Equals(EventId))
                    .Select(x=> new Event
                    {
                        EventId= x.EventId,
                        EventBookerId= x.EventBookerId,
                    })
                    .FirstOrDefaultAsync();
                Verify verify = new Verify();
                var family = await this.context.Family.Where(x=>x.EventBookerId.Equals(check.EventBookerId)).ToListAsync();
                var participant = await this.context.Participant.Where(x=>x.EventId.Equals(check.EventId)).ToListAsync();
                if (check != null)
                {
                    verify.EventId = check.EventId;
                    verify.VerifyCode ="Owner#"+ check.EventId.ToString() + check.EventBookerId.ToString();
                    await this.context.AddAsync(verify);
                    this.context.SaveChanges();

                    // family
                    foreach(var item in family)
                    {
                        verify = new Verify();
                        verify.EventId = check.EventId;
                        verify.VerifyCode = "Family#" + check.EventId.ToString() + "#"+item.MemberPhone.ToString();
                        await this.context.AddAsync(verify);
                        this.context.SaveChanges();
                    }

                    // participant
                    foreach (var item in participant)
                    {
                        verify = new Verify();
                        verify.EventId = check.EventId;
                        verify.VerifyCode = "Participant#" + check.EventId.ToString() + "#" + item.PhoneParticipant.ToString();
                        await this.context.AddAsync(verify);
                        this.context.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertVerifyCodeEvent1(string EventId)
        {
            try
            {
                Event check = this.context.Event.Where(x => x.EventId.Equals(EventId)).FirstOrDefault();
                Verify verify = new Verify();
                if (check != null)
                {
                    verify.EventId = check.EventId;
                    verify.VerifyCode = check.EventId.ToString() + check.EventBookerId.ToString();
                    this.context.Add(verify);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<VerifyNotificationRespone> checkdata(string code)
        {
            try
            {
                var result = new VerifyNotificationRespone();
                string[] data = code.Split('#');
                result.eventid= data[1];
                result.Relation = data[0];
                result.phone= data[2];
                return result;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
