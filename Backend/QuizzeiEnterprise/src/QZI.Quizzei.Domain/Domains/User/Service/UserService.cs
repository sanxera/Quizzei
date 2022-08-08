using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.User.Entities;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

namespace QZI.Quizzei.Domain.Domains.User.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void RegisterUser(BaseUser baseUser)
        {
            
        }

        public async Task<Entities.BaseUser> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

            return new Entities.BaseUser { Email = user.Email, Id = Guid.Parse(user.Id) };
        }
    }
}
