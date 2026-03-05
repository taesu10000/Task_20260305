using Application.Interfaces.Handlers;

namespace Application.Handlers.GetContact
{
    public class GetContactHandler : IGetContactHandler
    {
        public async Task<GetContactResult> ExecuteAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
