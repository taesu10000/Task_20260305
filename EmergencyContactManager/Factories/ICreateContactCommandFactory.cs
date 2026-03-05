using Application.Handlers.CreateContact;
using EmergencyContactManager.Models.Request;

namespace EmergencyContactManager.Factories
{
    public interface ICreateContactCommandFactory
    {
        Task<CreateContactCommand> CreateCmdAsync(ContactCreateRequest req, CancellationToken ct = default);
    }

}