using Application.Handlers.CreateContact;
using EmergencyContactManager.Models.Request;

namespace EmergencyContactManager.Factories
{
    public sealed class CreateContactCommandFactory : ICreateContactCommandFactory
    {
        public async Task<CreateContactCommand> CreateCmdAsync(ContactCreateRequest req, CancellationToken ct)
        {
            if (req.File is not null && req.File.Length > 0)
            {
                // HTTP lifetime 문제 피하려면 복사해서 넘기는 걸 권장
                var ms = new MemoryStream();
                await req.File.CopyToAsync(ms, ct);
                ms.Position = 0;
                return new CreateContactCommand(ms, req.Raw);
            }

            return new CreateContactCommand(null, req.Raw);
        }
    }

}