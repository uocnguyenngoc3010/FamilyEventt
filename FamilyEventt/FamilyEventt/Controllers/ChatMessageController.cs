using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        public IChat chatService;
        public ChatMessageController(IChat chatService)
        {
            this.chatService = chatService;
        }

        [Route("search-by-id-eventbooker")]
        [HttpGet]
        public async Task<IActionResult> GetChatByEventBookerID(string ID)
        {
            ResponseAPI<List<ChatMessage>> responseAPI = new ResponseAPI<List<ChatMessage>>();
            try
            {
                responseAPI.Data = await this.chatService.SearchByEventBooker(ID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("chat-mesage")]
        [HttpPost]
        public async Task<IActionResult> ChatMessage(ChatMessageDto message)
        {
            ResponseAPI<List<ChatMessage>> responseAPI = new ResponseAPI<List<ChatMessage>>();
            try
            {
                responseAPI.Data = await this.chatService.InsertMessage(message);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }



        [Route("delete-chat")]
        [HttpDelete]
        public async Task<IActionResult> DeleteChat(string id)
        {
            ResponseAPI<List<ChatMessage>> responseAPI = new ResponseAPI<List<ChatMessage>>();
            try
            {
                responseAPI.Data = await this.chatService.DeleteMessage(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
