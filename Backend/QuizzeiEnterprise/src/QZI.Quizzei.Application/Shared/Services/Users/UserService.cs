using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Response;

namespace QZI.Quizzei.Application.Shared.Services.Users;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<GetUserResponse> GetUserAsync(string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
            throw new GenericException($"User not found for email: {email}");

        var role = await _userManager.GetRolesAsync(user);
        var roleMain = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == role.FirstOrDefault());

        return new GetUserResponse
        {
            Email = user.Email!,
            UserUuid = Guid.Parse(user.Id),
            NickName = user.NickName,
            RoleUuid = Guid.Parse(roleMain!.Id),
            RoleName = roleMain.Name!,
            Admin = roleMain.Id == "e8ef779f-015d-4b30-808d-5ba36c7aef2b"
        };
    }

    public async Task<GetUserResponse> GetUserAsync(Guid userUuid)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userUuid.ToString());

        if (user == null)
            throw new GenericException($"User not found for id: {userUuid}");

        var role = await _userManager.GetRolesAsync(user);
        var roleMain = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == role.FirstOrDefault());

        return new GetUserResponse
        {
            Email = user.Email!,
            UserUuid = Guid.Parse(user.Id),
            NickName = user.NickName,
            RoleUuid = Guid.Parse(roleMain!.Id),
            RoleName = roleMain.Name!,
            Admin = roleMain.Id == "e8ef779f-015d-4b30-808d-5ba36c7aef2b"
        };
    }
}