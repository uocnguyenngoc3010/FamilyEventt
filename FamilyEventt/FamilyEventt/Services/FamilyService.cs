using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Common;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class FamilyService : IFamily
    {
        protected readonly FamilyEventContext context;
        public FamilyService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteFamily(List<string> id)
        {
            try
            {
                List<Family> familys = await this.context.Family
                    .Where(x => id.Contains(x.MemberId))
                    .ToListAsync();
                if (familys != null && familys.Count > 0)
                {

                    for (int i = 0; i < familys.Count; i++)
                    {
                        familys[i].Status = false;
                    }
                    await this.context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException("No Member found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<Family>> FilterFamilyByManyOption(string? name, string? phone, string? relation, bool? familyOption = true)
        {
            try
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                var data = await this.context.Family
                    .Where(x => phone == null ? true : x.MemberPhone.Contains(phone))
                    .Where(x=> x.Status == familyOption)
                    .ToListAsync();
               
                data = data.Where(x => name == null ? true : DataHelper.RemoveUnicode(x.MemberName).ToLower().Contains(name)).ToList();
                data = data.Where(x => relation == null ? true : DataHelper.RemoveUnicode(x.Relation).ToLower().Contains(relation)).ToList();
                var family = data.Select(x => new Family
                {
                    Id = x.Id,
                    EventBookerId = x.EventBookerId,
                    MemberId = x.MemberId,
                    MemberName = x.MemberName,
                    MemberPhone = x.MemberPhone,
                    Gender = x.Gender,
                    DateOfBirth = x.DateOfBirth,
                    Description = x.Description,
                    Relation = x.Relation,
                    Status = x.Status,
                    EventBooker = new EventBooker
                    {
                        EventBookerId = x.EventBooker.EventBookerId,
                        Fullname = x.EventBooker.Fullname,
                        Email = x.EventBooker.Email,
                        Address = x.EventBooker.Address,
                        Gender = x.EventBooker.Gender,
                        DateOfBirth = x.EventBooker.DateOfBirth,
                        Image = x.EventBooker.Image,
                        Status = x.EventBooker.Status,
                    }
                }).ToList();
                return family;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<Family>> GetAllFamily()
        {
            try
            {
                var data = await this.context.Family.Where(x => x.Status )
                                                    .Select(x => new Family
                {
                    Id = x.Id,
                    EventBookerId = x.EventBookerId,
                    MemberId = x.MemberId,
                    MemberName = x.MemberName,
                    MemberPhone = x.MemberPhone,
                    Gender = x.Gender,
                    DateOfBirth = x.DateOfBirth,
                    Description = x.Description,
                    Relation = x.Relation,
                    Status = x.Status,
                    EventBooker = new EventBooker
                    {
                        EventBookerId = x.EventBooker.EventBookerId,
                        Fullname = x.EventBooker.Fullname,
                        Email= x.EventBooker.Email,
                        Address= x.EventBooker.Address,
                        Gender= x.EventBooker.Gender,
                        DateOfBirth = x.EventBooker.DateOfBirth,
                        Image = x.EventBooker.Image,
                        Status= x.EventBooker.Status,
                    }
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<FamilyDto> GetFamilyMemberById(string id)
        {
            try
            {
                var data = await this.context.Family
                                          .Where(x => (x.MemberId == id || x.EventBookerId == id) && x.Status)
                                          .Select(x => new FamilyDto
                                              {
                                              Id = x.Id,
                                              EventBookerId = x.EventBookerId,
                                              MemberId = x.MemberId,
                                              MemberName = x.MemberName,
                                              MemberPhone = x.MemberPhone,
                                              Gender = x.Gender,
                                              DateOfBirth = x.DateOfBirth,
                                              Description = x.Description,
                                              Relation = x.Relation,
                                              Status = x.Status,
                                              EventBooker = new EventBookerDto
                                              {
                                                  EventBookerId = x.EventBooker.EventBookerId,
                                                  Fullname = x.EventBooker.Fullname,
                                                  Email = x.EventBooker.Email,
                                                  Address = x.EventBooker.Address,
                                                  Gender = x.EventBooker.Gender,
                                                  DateOfBirth = x.EventBooker.DateOfBirth,
                                                  Image = x.EventBooker.Image,
                                                  Status = x.EventBooker.Status,
                                              }
                                          }).FirstOrDefaultAsync();
                return data;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
            
        }

        public async Task<Family> InsertFamilyMember(FamilyDto family)
        {
            try
            {
                var member = await this.context.Account.Where(x=>x.Phone.Equals(family.MemberPhone)).FirstOrDefaultAsync();
                if (member == null)
                {
                    family.MemberId = null;
                }
                else
                {
                    var check = await this.context.EventBooker.Where(x=>x.EventBookerId.Equals(member.AccountId)).FirstOrDefaultAsync();
                    family.MemberId = check.EventBookerId;
                }
                var _family = new Family();
                _family.Id =  family.Id;
                _family.EventBookerId = family.EventBookerId;
                //_family.MemberId = "MId:" + Guid.NewGuid().ToString().Substring(0, 20);
                _family.MemberId= family.MemberId;
                _family.MemberName = family.MemberName;
                _family.MemberPhone = family.MemberPhone;
                _family.Gender = family.Gender; 
                _family.DateOfBirth = family.DateOfBirth;
                _family.Description = family.Description;
                _family.Relation = family.Relation;
                _family.Status= family.Status;
                await this.context.AddAsync(_family);
                await this.context.SaveChangesAsync();
                return _family;
             
            }
            catch (Exception ex)
            {
                throw new Exception("Success went wrong");
            }
        }

        public async Task<List<Family>> SearchByNameFamilyMember(string name)
        {
            try
            {
                var data = await this.context.Family
                    .Where(x => x.Status && x.MemberName.Contains(name))
                    .ToListAsync();
                return data;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Family>> GetFamilyByEventBooker(string id)
        {
            try
            {
                var data = await this.context.Family
                    .Where(x => x.Status && x.EventBookerId.Equals(id))
                    .ToListAsync();
                return data;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Family> UpdateFamily(FamilyDto upFamily)
        {
            try
            {
                var family = await this.context.Family
                    .Where(x =>x.Id == upFamily.Id)
                    .FirstOrDefaultAsync();
                if (family == null)
                {
                    throw new Exception("Please enter id memberId or EventBookerId");
                }
                else
                {
                    family.MemberName = upFamily.MemberName;
                    family.MemberPhone= upFamily.MemberPhone;
                    family.Gender= upFamily.Gender;
                    family.DateOfBirth= upFamily.DateOfBirth;
                    family.Description= upFamily.Description;
                    family.Relation = upFamily.Relation;
                    family.Status = true;
                    this.context.Family.Update(family);
                    await this.context.SaveChangesAsync();
                 
                    return family;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Process went wrong");
            }
        }
    }
}
