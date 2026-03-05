using Application.Handlers.CreateContact;
using EmergencyContactManager.Models.Request;

namespace EmergencyContactManager.Factories
{
    public sealed class CreateContactCommandFactory : ICreateContactCommandFactory
    {
        public async Task<CreateContactCommand> ReadContentAsync(HttpRequest request, ContactCreateRequest req, CancellationToken ct = default)
        {
            var content = string.Empty;
            if (request.HasFormContentType)
            {
                if (req.File is not null && req.File.Length > 0)
                {
                    using var reader = new StreamReader(req.File.OpenReadStream(), leaveOpen: false);
                    content = await reader.ReadToEndAsync(ct);
                }
            }
            else
            {
                using var reader = new StreamReader(request.Body, detectEncodingFromByteOrderMarks: true);
                content = (await reader.ReadToEndAsync(ct)).Trim();
            }
            return new CreateContactCommand(content);
        }
    }

}