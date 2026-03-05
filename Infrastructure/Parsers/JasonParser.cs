using Application.Interfaces.Services;
using Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Parsers;

public class JasonParser : IParsingService
{
    private readonly IFileStoreService fileStoreService;
    public JasonParser(IFileStoreService fileStoreService)
    {
        this.fileStoreService = fileStoreService;
    }
    public bool CanParse(string content)
    {
		try
		{
            JsonDocument.Parse(content);
            return true;
        }
		catch (Exception)
		{
            return false;
		}
    }
}
