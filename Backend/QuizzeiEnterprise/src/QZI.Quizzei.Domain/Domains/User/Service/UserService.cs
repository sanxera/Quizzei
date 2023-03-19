#nullable enable
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.User.Entities;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.User.Service.Request;
using QZI.Quizzei.Domain.Domains.User.Service.Response;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.User.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
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

        public async Task<UserBaseResponse> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

            return (user is null ? null :
                new UserBaseResponse { Email = user.Email, Id = Guid.Parse(user.Id), NickName = user.NickName })!;
        }

        public async Task<UserBaseResponse> GetUserById(Guid userUuid)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userUuid.ToString());

            return (user is null ? null :
                new UserBaseResponse { Email = user.Email, Id = Guid.Parse(user.Id), NickName = user.NickName })!;
        }

        public async Task<GetUserDetailsResponse?> GetUserDetails(GetUserDetailsRequest request)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserUuid.ToString());

            if (user is null)
                return null;

            var role = await _userManager.GetRolesAsync(user);
            var roleMain = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == role.FirstOrDefault());

            return new GetUserDetailsResponse 
                { 
                    Email = user.Email,
                    UserUuid = Guid.Parse(user.Id),
                    NickName = user.NickName, 
                    RoleUuid = Guid.Parse(roleMain.Id),
                    RoleName = roleMain.Name,
                    Admin = roleMain.Id == "e8ef779f-015d-4b30-808d-5ba36c7aef2b"
            };
        }

        public async Task<GetUserDetailsResponse?> GetUserDetails(GetLoggedUserDetailsRequest request)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user is null)
                return null;

            var role = await _userManager.GetRolesAsync(user);
            var roleMain = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == role.FirstOrDefault());

            //TODO: ARRUMAR ISSO DEPOIS  JT-42
            return new GetUserDetailsResponse
            {
                Email = user.Email,
                UserUuid = Guid.Parse(user.Id),
                NickName = user.NickName,
                RoleUuid = Guid.Parse(roleMain!.Id),
                RoleName = roleMain.Name,
                Admin = roleMain.Id == "e8ef779f-015d-4b30-808d-5ba36c7aef2b"
            };
        }

        private async Task AssignRoleToUser(ApplicationUser user, Guid roleGuid)
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
