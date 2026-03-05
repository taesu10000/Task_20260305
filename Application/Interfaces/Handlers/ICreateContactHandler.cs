using Application.Handlers.CreateContact;

namespace Application.Interfaces.Handlers
{
    public interface ICreateContactHandler
    {
        Task<CreateContactResult> ExecuteAsync(CreateContactCommand contact, CancellationToken ct = default);
    }
}