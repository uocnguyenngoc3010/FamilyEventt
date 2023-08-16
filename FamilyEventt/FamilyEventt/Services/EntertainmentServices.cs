using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using GoogleApi.Entities.Search.Video.Common;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class EntertainmentServices : IEntertainment
    {
        protected readonly FamilyEventContext context;
        public EntertainmentServices(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteEntertainment(string[] EntertainmentId)
        {
            try
            {
                List<Entertainment> entertaiments = await this.context.Entertainment
                    .Where(x => EntertainmentId.Contains(x.EntertainmentId))
                    .ToListAsync();
                if (entertaiments != null && entertaiments.Count > 0)
                {

                    for (int i = 0; i < entertaiments.Count; i++)
                    {
                        entertaiments[i].Status = false;
                    }
                    await this.context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException("No Entertainment found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<Entertainment>> GetAllEntertainments()
        {
            try
            {

                var data = await this.context.Entertainment.Where(x => x.Status).Select(x => new Entertainment
                {
                    EntertainmentId = x.EntertainmentId,
                    EntertainmentTotal= x.EntertainmentTotal,
                    Status = x.Status,
                }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<Entertainment> GetByIdEntertainments(string? EntertainmentId)
        {
            try
            {
                var idEntertainment = await this.context.Entertainment.Where(x => x.Status && x.EntertainmentId == EntertainmentId).Select(x => new Entertainment()
                {
                    EntertainmentId = x.EntertainmentId,
                    EntertainmentTotal = x.EntertainmentTotal,
                    Status = x.Status,
                }).FirstOrDefaultAsync();
                return idEntertainment;
            }
            catch (Exception ex)
            {
                throw new Exception("process wrong connect");
            }
        }

        public async Task<Entertainment> InserEntertainment(EntertainmentDto entertainment)
        {
            Entertainment _newEntertainment= new Entertainment();
            // "FID" + DateTime.Now.ToString("MMddyyHmmss"): use time for get Id
            //"FID" + DateTime.Now.ToString("MMddyyHmmss")
           _newEntertainment.EntertainmentId = "EId" + Guid.NewGuid().ToString().Substring(0,20);
            _newEntertainment.EntertainmentTotal = entertainment.EntertainmentTotal;
            _newEntertainment.Status = true;
            await this.context.Entertainment.AddAsync(_newEntertainment);
            this.context.SaveChanges();
            return _newEntertainment;
        }

        public async Task<bool> UpdateEntertainment(EntertainmentDto upEntertainment)
        {
            try
            {
                int count = 0;
                Entertainment entertainment = await this.context.Entertainment.FirstOrDefaultAsync(x =>x.Status && x.EntertainmentId == upEntertainment.EntertainmentId);
                if (entertainment != null)
                {
                    entertainment.EntertainmentId = upEntertainment.EntertainmentId;
                    var check = await this.context.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(entertainment.EntertainmentId)).ToListAsync();
                    if (check != null)
                    {
                        foreach(var item in check)
                        {
                            count++;
                        }
                    }
                    entertainment.EntertainmentTotal = count*10000;
                    entertainment.Status = true;
                    //this.context.Add(entertainment);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Not Found Entertainment!");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
