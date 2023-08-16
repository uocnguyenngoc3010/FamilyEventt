using FamilyEventt.Interfaces;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace FamilyEventt.Services
{
    public class TwillioService : ITwillioService
    {
        private readonly IConfiguration _configuration;
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _pathServiceSid;
        private readonly string TWILLIO_VERIFICATIONS_URL;

        public TwillioService(IConfiguration configuration)
        {
            this._configuration = configuration;
            _accountSid = _configuration.GetValue<string>("twillio:accountsid");
            _authToken = _configuration.GetValue<string>("twillio:authtoken");
            _pathServiceSid = _configuration.GetValue<string>("twillio:pathservicesid");
        }

        public async Task<DateTime?> SendOTP(string phoneNumber)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var verification = await VerificationResource.CreateAsync(
                to: phoneNumber,
                channel: "sms",
                pathServiceSid: _pathServiceSid,
                locale: "vi"
                );
            
            return verification.DateCreated;
        }

        public async Task<string> VerifyOTP(string phoneNumber, string otp)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var verificationResult = await VerificationCheckResource.CreateAsync(
                to: phoneNumber,
                code: otp,
                pathServiceSid: _pathServiceSid
                );

            return verificationResult.Status.ToString();
        }
    }
}
