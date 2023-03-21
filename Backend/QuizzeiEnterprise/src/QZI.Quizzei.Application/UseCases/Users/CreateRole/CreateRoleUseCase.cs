using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Interfaces;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Models.Request;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Users.CreateRole;

internal class CreateRoleUseCase : ICreateRoleUseCase
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateRoleUseCase(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<CreateRoleResponse> ExecuteAsync(CreateRoleRequest request)
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

        return CreateRoleResponse.Create(Guid.Parse(newRole.Id));
    }

    private static void ValidateResult(IdentityResult result)
    {
        if (!result.Succeeded)
            throw new GenericException("Error to create a new role");
    }
}