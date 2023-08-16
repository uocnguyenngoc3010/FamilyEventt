using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class ChatMessageService : IChat
    {
        protected readonly FamilyEventContext context;

        public ChatMessageService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteMessage(string chatMessage)
        {
            try
            {
                var chat = await this.context.ChatMessage.Where(x=>x.ChatId== chatMessage).FirstOrDefaultAsync();
                if (chat != null)
                {
                    chat.Status = false;
                    this.context.ChatMessage.Update(chat);
                    await this.context.SaveChangesAsync();
                    await this.context.ChatMessage.LoadAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex) {
                return false;
            }
        }

        public async Task<bool> InsertMessage(ChatMessageDto chatMessage)
        {
            try
            {
                var message = new ChatMessage();
                message.ChatId = "ChatID" + Guid.NewGuid().ToString().Substring(0,17);
                message.EventBookerId = chatMessage.EventBookerId;  
                message.StaffId = chatMessage.StaffId;
                message.Status = true;
                message.Message = chatMessage.Message;
                message.Date = DateTime.Now;

                await this.context.ChatMessage.AddAsync(message);
                this.context.SaveChangesAsync();
                await this.context.ChatMessage.LoadAsync();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ChatMessage>> SearchByEventBooker(string ID)
        {
            try
            {
                var chat = await this.context.ChatMessage
                    .Where(x => x.Status && x.EventBookerId == ID).ToListAsync();
                if (chat == null)
                {
                    return null;
                }
                else
                {
                    await this.context.ChatMessage.LoadAsync();
                    return chat;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
