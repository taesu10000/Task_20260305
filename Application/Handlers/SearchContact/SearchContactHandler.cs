using Application.Interfaces.Handlers;

namespace Application.Handlers.SearchContact
{
    public class SearchContactHandler : ISearchContactHandler
    {
        public Task<List<SearchContactResult>> ExecuteAsync(SearchContractQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
