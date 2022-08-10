using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.User.Entities;
using QZI.Quizzei.Domain.Domains.User.Request;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Exceptions;

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

        public async Task<Guid> CreateUser(CreateUserRequest request)
        {
            var userAlreadyCreated = await _userManager.Users.FirstOrDefaultAsync
                (x => x.Email == request.Email);

            if (userAlreadyCreated != null)
                throw new GenericException("Email/UserName already exists");

            var newUser = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
                Name = request.Name,
                NickName = request.NickName
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            ValidateResult(result);
            await AssignRoleToUser(newUser, request.RoleId);

            return Guid.Parse(newUser.Id);
        }

        public async Task<Guid> CreateRole(CreateRoleRequest request)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (role != null)
                throw new GenericException("Role with this name already created");

            var newRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name
            };

            var result = await _roleManager.CreateAsync(newRole);

            ValidateResult(result);

            return Guid.Parse(newRole.Id);
        }


        public async Task<BaseUser> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

            return new BaseUser { Email = user.Email, Id = Guid.Parse(user.Id) };
        }

        private async Task AssignRoleToUser(IdentityUser user, Guid roleGuid)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleGuid.ToString());

            if (role is null)
                throw new GenericException("Role with this name already created");

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        private static void ValidateResult(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new GenericException("Error to create a new role");
        }
    }
}
