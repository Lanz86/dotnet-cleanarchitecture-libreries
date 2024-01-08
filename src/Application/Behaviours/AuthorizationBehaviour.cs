using MediatR;
using System.Reflection;
using LanzDev.CleanArchitecture.Libraries.Application.Interfaces;
using LanzDev.CleanArchitecture.Libraries.Application.Security;
using LanzDev.CleanArchitecture.Libraries.Application.Exceptions;

namespace LanzDev.CleanArchitecture.Libraries.Application.Behaviours;
public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUser _user;

    public AuthorizationBehaviour(
        IUser user)
    {
        _user = user;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            // Must be authenticated user
            if (_user.Id == null)
            {
                throw new UnauthorizedAccessException();
            }

            // Role-based authorization
            var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

            if (authorizeAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    foreach (var role in roles)
                    {
                        authorized = _user.Roles?.Count(x => x == role) > 0;
                        break;
                    }
                }

                // Must be a member of at least one role in roles
                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }

            // Permission-based authorization
            var authorizeAttributesWithPermissions = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Permissions));

            if (authorizeAttributesWithPermissions.Any())
            {
                var authorized = false;

                foreach (var permissions in authorizeAttributesWithPermissions.Select(a => a.Permissions.Split(',')))
                {
                    foreach (var permission in permissions)
                    {
                        authorized = _user.Permissions?.Count(x => x == permission) > 0;
                        break;
                    }
                }

                // Must be a member of at least one role in roles
                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }
        }

        // User is authorized / authorization not required
        return await next();
    }
}
