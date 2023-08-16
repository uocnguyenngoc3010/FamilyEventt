using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class ParticipantService : IParticipant
    {
        protected readonly FamilyEventContext context;
        public ParticipantService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<List<Participant>> GetAllParticipant()
        {
            try
            {
                var Participant = await this.context.Participant.ToListAsync();
                if (Participant == null)
                {
                    return null;
                }
                else
                {
                    return Participant;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Participant>> GetParticipantsByEvent(string ID)
        {
            try
            {
                var Participant = await this.context.Participant.Where(x=>x.EventId.Equals(ID)).ToListAsync();
                if (Participant == null)
                {
                    return null;
                }
                else
                {
                    return Participant;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> InsertParticipant(ParticipantDto participant)
        {
            try
            {
                var particpant = new Participant();
                particpant.PhoneParticipant = participant.PhoneParticipant;
                particpant.FullNameParticipant = participant.FullNameParticipant;
                particpant.EventId = "EId" + Guid.NewGuid().ToString().Substring(0, 20);
                participant.Relation = participant.Relation;
                await this.context.Participant.AddAsync(particpant);
                this.context.SaveChanges();
                this.context.Event.Load();
                return true;
            }
            catch (Exception ex) { 
                return false; 
            }
        }

        public async Task<bool> UpdateParticipant(ParticipantDto participant)
        {
            try
            {
                var uptParticpant = await this.context.Participant.Where(x=>x.EventId.Equals(participant.EventId)).FirstOrDefaultAsync();
                if (uptParticpant == null) { 
                    return false;
                }
                else
                {
                    uptParticpant.PhoneParticipant = participant.PhoneParticipant;
                    uptParticpant.FullNameParticipant = participant.FullNameParticipant;
                    uptParticpant.EventId = participant.EventId;
                    participant.Relation = participant.Relation;
                    context.Participant.Update(uptParticpant);
                    this.context.SaveChanges();
                    this.context.Event.Load();
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
