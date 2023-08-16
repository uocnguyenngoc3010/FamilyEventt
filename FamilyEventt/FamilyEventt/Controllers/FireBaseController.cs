using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FireBaseController : ControllerBase
    {
        private readonly FamilyEventContext _context;
        private readonly IConfiguration _config;
        //private readonly ITwillioService _twillioService;
        private IFireBase _firebaseService;
        public FireBaseController(IFireBase firebaseService,
            FamilyEventContext context,
            IConfiguration config
            )
        {
            this._firebaseService = firebaseService;
            _context = context;
            _config = config;

        }
        /// <summary>
        /// Send notification many number Phone
        /// </summary>
        /// <param name="firebaseService"></param>
        /// <returns></returns>
        [HttpGet("Notification-Sms")]
        public async Task<IActionResult> TestSendMessage([FromServices] FirebaseService firebaseService)
        {
            //Title Notification
            string title = "test noti ne";
            //body Notification
            string body = "noti den nay ba con oi";
            //token: đợi MB truyền vô
            string token = "";
            //Gắn link mã QR 
            string imageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fpixabay.com%2Fimages%2Fsearch%2Fnature%2F&psig=AOvVaw220Vu4fiDJLphfoWiVu3VH&ust=1681631614275000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCODxu4q0q_4CFQAAAAAdAAAAABAE";
            await firebaseService.SendMessage(token, title, body, imageUrl);
            return Ok();
        }
    }
}
