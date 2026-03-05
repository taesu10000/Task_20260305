using Application.Interfaces.Handlers;
using Application.Resolver;

namespace Application.Handlers.CreateContact
{
    public class CreateContactHandler : ICreateContactHandler
    {
        private readonly IContactParserResolver contactParserResolver;
        public CreateContactHandler(IContactParserResolver contactParserResolver)
        {
            this.contactParserResolver = contactParserResolver;
        }
        public async Task<CreateContactResult> ExecuteAsync(CreateContactCommand cmd, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
        private static async Task<string> GetContent(CreateContactCommand cmd, CancellationToken ct)
        {
            string content;
            //File인지 Raw인지 판단하여 content에 저장
            if (cmd.FileStream is not null)
            {
                using var reader = new StreamReader(cmd.FileStream, leaveOpen: false);
                content = await reader.ReadToEndAsync(ct);
            }
            else if (!string.IsNullOrWhiteSpace(cmd.Raw))
            {
                content = cmd.Raw;
            }
            else
                throw new InvalidOperationException("At least either of File or Raw required.");
            return content;
        }
    }
}
