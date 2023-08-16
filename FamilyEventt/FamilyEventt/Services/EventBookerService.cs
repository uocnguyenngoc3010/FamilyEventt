using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class EventBookerService : IEventBooker
    {
        protected readonly FamilyEventContext context;
        public EventBookerService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteEventBooker(string id)
        {
            try
            {
                EventBooker eventBooker = await this.context.EventBooker.FirstOrDefaultAsync(x => x.EventBookerId == id);
                if (eventBooker != null)
                {

                    eventBooker.Status = false;
                    this.context.SaveChanges();
                    return true;

                }
                else
                {
                    throw new Exception("Not Found Event Booker!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<EventBooker>> GetAllEventBookers()
        {
            try
            {
                var data = await this.context.EventBooker.Where(x => x.Status)
                    //.Include(x=>x.Family)
                    //.Include(x=>x.Event)
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllEventBookers" + ex.Message);
            }
        }

        public async Task<EventBooker> GetByIdEventbooker(string? Id)
        {
            try
            {
                EventBooker EB = await this.context.EventBooker
                    .Where(x => x.Status && (x.EventBookerId == Id || x.EventBookerId == null))
                    .Select(x => new EventBooker()
                    {
                        EventBookerId = x.EventBookerId,
                        Fullname= x.Fullname,
                        Email= x.Email,
                        Phone= x.Phone,
                        Address= x.Address,
                        Gender= x.Gender,
                        DateOfBirth= x.DateOfBirth,
                        Image= x.Image,
                        Status= x.Status,
                        

                    })
                    //.Include(x => x.Family)
                    //.Include(x => x.Event)
                    .FirstOrDefaultAsync();
                return EB;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<EventBooker> GetEventBookerByPhone(string phone)
        {

            try
            {
                var check = await this.context.Account
                    .Where(x=>x.Phone.Equals(phone) && x.Role.Equals("eventBooker") && x.Status)
                    
                    .FirstOrDefaultAsync();
                if(check == null)
                {
                    throw new Exception("không tìm thấy sdt trong account");
                    return null;
                }
                var result = await this.context.EventBooker
                    .Where(x => x.Phone.Equals(check.Phone) && x.Status)
                    .Select(x => new EventBooker()
                    {
                        Address = x.Address,
                        DateOfBirth = x.DateOfBirth,
                        Image = x.Image,
                        Email = x.Email,
                        EventBookerId = x.EventBookerId,
                        Fullname = x.Fullname,
                        RegisterDate = x.RegisterDate,
                        Gender = x.Gender,
                        Phone = x.Phone,
                        Status = x.Status,
                    })
                    .FirstOrDefaultAsync();
                if(result == null)
                {
                    throw new Exception("chưa đăng ký thông tin");
                    return null;
                }
                else
                {
                    return result;
                }
            }catch(Exception ex)
            {
                throw new Exception("chưa có data trong account");
            }
        }
        public async Task<bool> InsertEventBooker(EventBookerDto eventBooker)
        {
            try
            {
                var check = await this.context.Account
                    .Where(x => x.Phone.Equals(eventBooker.Phone) && x.Role.Equals("eventBooker") &&x.Status)
                    .FirstOrDefaultAsync();
                if (check == null) 
                {
                    return false;
                }
                var _eventBooker = new EventBooker();
                _eventBooker.EventBookerId = check.AccountId;
                _eventBooker.Fullname = eventBooker.Fullname;
               /* _eventBooker.Email = eventBooker.Email;
                _eventBooker.Phone = eventBooker.Phone;
                _eventBooker.Password = eventBooker.Password;*/
                _eventBooker.Email = eventBooker.Email;
                _eventBooker.Phone = check.Phone;
                _eventBooker.RegisterDate = DateTime.Now;
                _eventBooker.Address = eventBooker.Address;
                _eventBooker.Gender= eventBooker.Gender;
                _eventBooker.DateOfBirth= eventBooker.DateOfBirth;
                _eventBooker.Image = eventBooker.Image;
                _eventBooker.Status= true;
                await this.context.EventBooker.AddAsync(_eventBooker);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> InsertEventBookerfield(string Phone, string fullname, string addr, bool gender)
        {
            try
            {
                var check = await this.context.Account
                    .Where(x => x.Phone.Equals(Phone) && x.Role.Equals("eventBooker") && x.Status)
                    .FirstOrDefaultAsync();
                if (check == null)
                {
                    return false;
                }
                var _eventBooker = new EventBooker();
                _eventBooker.EventBookerId = check.AccountId;
                _eventBooker.Fullname = fullname;
                /* _eventBooker.Email = eventBooker.Email;
                 _eventBooker.Phone = eventBooker.Phone;
                 _eventBooker.Password = eventBooker.Password;*/
                _eventBooker.Email = "null";
                _eventBooker.Phone = check.Phone;
                _eventBooker.RegisterDate = DateTime.Now;
                _eventBooker.Address = addr;
                _eventBooker.Gender = gender;
                _eventBooker.DateOfBirth = DateTime.Now;
                _eventBooker.Image = "null";
                _eventBooker.Status = true;
                await this.context.EventBooker.AddAsync(_eventBooker);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<EventBooker>> SearchByNameEventBooker(string name)
        {
            try
            {
                var data = await this.context.EventBooker.Where(x => x.Status && x.Fullname.Contains(name))
                    //.Include(x => x.Family)
                    //.Include(x => x.Event)
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<EventBooker> UpdateEventBooker(EventBookerDto upEventBooker)
        {
            try
            {
                EventBooker eventBooker = await this.context.EventBooker.FirstOrDefaultAsync(x => x.Phone.Equals(upEventBooker.Phone));
                if (eventBooker != null)
                {
                    //eventBooker.EventBookerId = upEventBooker.EventBookerId;
                    eventBooker.Fullname = upEventBooker.Fullname;
                    eventBooker.Email = upEventBooker.Email;
                    /*eventBooker.Email = upEventBooker.Email;
                    eventBooker.Phone = upEventBooker.Phone;
                    eventBooker.Password = upEventBooker.Password;*/
                    eventBooker.Address = upEventBooker.Address;
                    eventBooker.Gender = upEventBooker.Gender;
                    eventBooker.DateOfBirth = upEventBooker.DateOfBirth;
                    eventBooker.Image = upEventBooker.Image;
                    //eventBooker.Status = upEventBooker.Status;
                    this.context.EventBooker.Update(eventBooker);
                    this.context.SaveChanges();
                    return eventBooker;
                }
                else
                {
                    throw new Exception("Not Found Event Booker!");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
