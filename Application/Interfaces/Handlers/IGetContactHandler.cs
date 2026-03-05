using Application.Handlers.GetContact;

namespace Application.Interfaces.Handlers;

public interface IGetContactHandler
{
    Task<GetContactResult> ExecuteAsync(string name);
}