using BCrypt.Net;
using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace FamilyEventt.Services
{
    public class AccountService : IAccount
    {
        protected readonly FamilyEventContext context;
        private readonly IConfiguration _config;
        public AccountService(FamilyEventContext context, IConfiguration config)
        {
            this.context = context;
            _config = config;
        }

        public string GenerateJSONWebToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {

                new Claim(JwtRegisteredClaimNames.Sub, account.Username ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, account.Email ?? ""),
                new Claim(ClaimTypes.MobilePhone, account.Phone ?? ""),
                new Claim(ClaimTypes.Role, account.Role),
            };

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task List<LoginEmail>(string email, string password)
        {
            /* try
             {
                 var accountEmail = await this.context.Account
                     .FirstOrDefaultAsync(x => x.Status && x.Email == email && x);
                 if (accountEmail == null)
                 {
                     throw new Exception("Account not exist");
                 }

                 if (accountEmail.Password != password )
                 {
                     throw new Exception("Wrong password");
                 }

             }
             catch (Exception ex)
             {

             }*/
        }

        /*public async Task<Account> GetByNumberPhone(string phone)
        {
            try
            {
                var getPhone = await this.context.Account
                .Where(x => x.Status && x.Phone == phone)
                .FirstOrDefaultAsync();
                
                return getPhone ;
            }
            catch(Exception ex) 
            {
                return null;
            }
            
        }*/
        public async Task<bool> RegisterStaff(RegisterStaffDto staff)
        {
            try
            {
                var usname = await this.context.Account.Where(x => x.Username.Equals(staff.Username) && x.Status).FirstOrDefaultAsync();
                if (usname != null)
                {
                    throw new Exception("Username is existed!");
                    return false;
                }
                else
                {
                    var newstaff = new Account();
                    newstaff.Username = staff.Username;
                    //BCrypt.Net.BCrypt.HashPassword( staff.Password)---> bâm password
                    newstaff.Password = BCrypt.Net.BCrypt.HashPassword(staff.Password);
                    //newstaff.Password =  staff.Password;
                    newstaff.AccountId = Guid.NewGuid().ToString().Substring(0, 25);
                    newstaff.Status = true;
                    newstaff.Email = staff.Email;
                    newstaff.Phone = staff.Phone;
                    newstaff.Role = "staff";

                    await this.context.Account.AddAsync(newstaff);
                    await this.context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
           

           

        }

        public async Task<Account> LoginStaff(string username, string password)
        {
            /*string passwordEnter = "sdadsa";
            string passdb = "sdadad";
            BCrypt.Net.BCrypt.Verify(passdb, passwordEnter);*/
            //BCrypt.Net.BCrypt.Verify(passdb, passwordEnter)
            try
            {
                var checkLogin = await this.context.Account
                    .Where(x => x.Username.Equals(username) && x.Status)
                    .FirstOrDefaultAsync();
                //check verify password
                if((BCrypt.Net.BCrypt.Verify(password, checkLogin.Password)))  {
                    return checkLogin;
                }
                else
                {
                    throw new Exception("Sai Password");
                }
                
                /*if (checkLogin == null)
                {
                    throw new Exception("user not exist!");
                }
                else
                {
                    //checkLogin.AccountId = null;
                    return checkLogin;
                }*/
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Account> UpdateStaff(UpdateStaffDto update)
        {
            try
            {
                var checkStaff = await this.context.Account
                    .Where(x => x.AccountId.Equals(update.accountId) && x.Status).FirstOrDefaultAsync();
                if (checkStaff == null)
                {
                    throw new Exception("Staff not existed");
                }
                else
                {
                    checkStaff.Password = BCrypt.Net.BCrypt.HashPassword(update.Password);
                    checkStaff.Email = update.Email;
                    checkStaff.Phone = update.Phone;
                    this.context.Account.Update(checkStaff);
                    await this.context.SaveChangesAsync();

                    return checkStaff;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            
        }

        public async Task<Account> DeleteStaff(string username)
        {
            try
            {
                var checkStaff = await this.context.Account
                    .Where(x => x.Username.Equals(username)
                && x.Status).FirstOrDefaultAsync();
                if (checkStaff == null)
                {
                    throw new Exception("Staff not existed");
                }
                else
                {
                    checkStaff.Status = false;
                    this.context.Account.Update(checkStaff);
                    await this.context.SaveChangesAsync();

                    return checkStaff;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Account> DeleteStaffById(string idStaff)
        {
            try
            {
                var checkStaff = await this.context.Account
                    .Where(x => x.AccountId.Equals(idStaff)
                && x.Status).FirstOrDefaultAsync();
                if (checkStaff == null)
                {
                    throw new Exception("Staff not existed");
                }
                else
                {
                    checkStaff.Status = false;
                    this.context.Account.Update(checkStaff);
                    await this.context.SaveChangesAsync();

                    return checkStaff;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Account>> GetAll()
        {
            try
            {
                var checkStaff = await this.context.Account.Where(x => x.Status && x.Role.Equals("staff")).ToListAsync();
                if (checkStaff == null)
                {
                    return null;
                }
                else
                {
                    return checkStaff;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Account> GetStaffByID(string id)
        {
            try
            {
                var checkStaff = await this.context.Account.Where(x => x.Role.Equals("staff") && x.AccountId.Equals(id)).FirstOrDefaultAsync();
                if (checkStaff == null)
                {
                    return null;
                }
                else
                {
                    return checkStaff;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Account> GetStaffByUsername(string username)
        {
            try
            {
                var checkStaff = await this.context.Account.Where(x => x.Role.Equals("staff") && x.Username.Equals(username)).FirstOrDefaultAsync();
                if (checkStaff == null)
                {
                    return null;
                }
                else
                {
                    return checkStaff;
                }
            }
            catch (Exception ex)
            {
                return null;
            };
        }
    }
}
