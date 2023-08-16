using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class AccountDto
    {
        
        public string Accountid { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
        
        public double Phone { get; set; }
       
        public string Password { get; set; }
        public string Role { get; set; }
        public string Otp { get; set; }
        public bool Status { get; set; }
        
        public string AuthToken { get; set; }
        
        public string IdToken { get; set; }
    }
}
