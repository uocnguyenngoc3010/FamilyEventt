namespace FamilyEventt.Interfaces
{
    public interface ITwillioService
    {
        Task<DateTime?> SendOTP(string phoneNumber);
        Task<string> VerifyOTP(string phoneNumber, string otp);
    }
}
