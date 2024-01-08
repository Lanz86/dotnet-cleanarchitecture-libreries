namespace LanzDev.CleanArchitecture.Libraries.Application.Interfaces;

public interface IUser
{
    string? Id { get; }
    string? Email { get; }
    public IEnumerable<string>? Roles { get; }
    public IEnumerable<string>? Permissions { get; }
}
