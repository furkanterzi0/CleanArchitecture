using CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class RoleAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly string _role;
    private readonly IUserRoleService _userRoleService;

    public RoleAttribute(string role, IUserRoleService userRoleService)
    {
        _role = role;
        _userRoleService = userRoleService;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userHasRole = await _userRoleService.GetRoleByUserId(userIdClaim.Value, _role);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
