using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace FamilyEventt.Services
{

    public class FirebaseService : IFireBase
    {
        protected readonly FamilyEventContext context;
        private readonly IConfiguration _config;
        public FirebaseService(FamilyEventContext context, IConfiguration config)
        {
            this.context = context;
            _config = config;
        }
        public async Task checkByEmailLogin(string email)
        {
            if (email != null)
            {

                var defaultAuth = FirebaseAuth.DefaultInstance;
                var e = await defaultAuth.GetUserByEmailAsync(email);
                //Console.WriteLine(e.Email);
                // Console.WriteLine(e.DisplayName);
            }
        }

        public async Task SendMessage(string token, string title, string body, string imageUrl)
        {
            Message message = new Message()
            {
                Token = token,
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    //tiêu đề thông báo
                    Title = title,
                    //truyền thông tin sự kiện vô 
                    Body = body,
                    //truyền hình mã khách mời
                    ImageUrl = imageUrl
                }
            };
            //await FirebaseMessaging.DefaultInstance.SendAllAsync() ---list many Notification
            await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}

