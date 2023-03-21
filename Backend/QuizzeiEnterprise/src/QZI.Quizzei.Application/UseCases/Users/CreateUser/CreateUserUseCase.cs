using Microsoft.AspNetCore.Identity;
using QZI.Quizzei.Application.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Response;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Interfaces;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Request;

namespace QZI.Quizzei.Application.UseCases.Users.CreateUser;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateUserUseCase(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request)
    {
        var userAlreadyCreated = await _userManager
            .Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

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

        return CreateUserResponse.Create(Guid.Parse(newUser.Id));
    }

    private async Task AssignRoleToUser(ApplicationUser user, Guid roleGuid)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleGuid.ToString());

        if (role is null)
            throw new GenericException("Role with this name already created");

        await _userManager.AddToRoleAsync(user, role.Name!);
    }

    private static void ValidateResult(IdentityResult result)
    {
        if (!result.Succeeded)
            throw new GenericException("Error to create a new role");
    }
}