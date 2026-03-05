using Application.Handlers.CreateContact;
using EmergencyContactManager.Models.Request;

namespace EmergencyContactManager.Factories
{
    public interface ICreateContactCommandFactory
    {
        Task<CreateContactCommand> ReadContentAsync(HttpRequest request, ContactCreateRequest req, CancellationToken ct = default);
    }

}