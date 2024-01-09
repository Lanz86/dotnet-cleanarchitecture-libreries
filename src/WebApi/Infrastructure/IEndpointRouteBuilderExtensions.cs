using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace LanzDev.CleanArchitecture.Libraries.WebApi.Infrastructure;

public static class IEndpointRouteBuilderExtensions
{
    public static IEndpointConventionBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler, string pattern = "")
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapGet(pattern,handler)
            .WithName(handler.Method.Name);
    }

    public static IEndpointConventionBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler, string pattern = "")
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapPost(pattern, handler)
            .WithName(handler.Method.Name);
    }

    public static IEndpointConventionBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, string pattern)
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapPut(pattern, handler)
            .WithName(handler.Method.Name);
    }

    public static IEndpointConventionBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, string pattern)
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapDelete(pattern, handler)
            .WithName(handler.Method.Name);
    }
}
