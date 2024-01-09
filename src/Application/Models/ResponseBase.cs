namespace LanzDev.CleanArchitecture.Libraries.Application.Models;

public class ResponseBase<T>(T id)
{
    public T Id { get; } = id;
}