using Microsoft.AspNetCore.Builder;

namespace LanzDev.CleanArchitecture.Libraries.WebApi.Infrastructure;

public abstract class EndpointGroupBase
{
    public abstract void Map(WebApplication app);
}
