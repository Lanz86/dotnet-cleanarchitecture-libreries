using System.Security.Claims;
using LanzDev.CleanArchitecture.Libraries.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LanzDev.CleanArchitecture.Libraries.WebApi.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue("sub");
    public string? Email => httpContextAccessor.HttpContext?.User?.FindFirstValue("email");

    public IEnumerable<string>? Roles => httpContextAccessor.HttpContext?.User?.FindAll("role")?.Select(x => x.Value)?.ToList();

    public IEnumerable<string>? Permissions => httpContextAccessor.HttpContext?.User?.FindAll("Permissions")?.Select(x => x.Value)?.ToList();

}