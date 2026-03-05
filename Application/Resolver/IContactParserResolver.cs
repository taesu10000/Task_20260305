using Application.Interfaces.Services;

namespace Application.Resolver
{
    public interface IContactParserResolver
    {
        IParsingService Resolve(string content);
    }

}
