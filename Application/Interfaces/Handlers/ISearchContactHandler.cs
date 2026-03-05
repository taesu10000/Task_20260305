using Application.Handlers.SearchContact;

namespace Application.Interfaces.Handlers
{
    public interface ISearchContactHandler
    {
        Task<List<SearchContactResult>> ExecuteAsync(SearchContractQuery query);
    }
}