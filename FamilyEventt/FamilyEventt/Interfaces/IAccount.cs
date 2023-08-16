using FamilyEventt.Dto;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyEventt.Interfaces
{
    public interface IAccount
    {
        string GenerateJSONWebToken(Account account);

        //Task<Account> GetByNumberPhone(string phone);

        //Task<IActionResult> LoginPhone(AccountLoginDto loginDto);
        Task<Account> DeleteStaffById(string idStaff);
        Task<bool> RegisterStaff(RegisterStaffDto staff);
        Task<Account> LoginStaff(string username, string password);
        Task<Account> UpdateStaff(UpdateStaffDto update);
        Task<List<Account>> GetAll();
        Task<Account> DeleteStaff(string username);
        Task<Account> GetStaffByID(string id);
        Task<Account> GetStaffByUsername(string username);

    }
}
