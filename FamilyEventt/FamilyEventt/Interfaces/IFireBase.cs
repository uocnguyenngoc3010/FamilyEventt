namespace FamilyEventt.Interfaces
{
    public interface IFireBase
    {
        Task checkByEmailLogin(string email);
        Task SendMessage(string token, string title, string body, string imageUrl);
    }
}
