using Application.Interfaces.Services;
using CsvHelper;
using System.Globalization;


namespace Infrastructure.Parsers;

public class CSVParser : IParsingService
{
    private readonly IFileStoreService fileStoreService;
    public CSVParser(IFileStoreService fileStoreService)
    {
        this.fileStoreService = fileStoreService;
    }
    public bool CanParse(string content)
    {
		try
		{
            using var reader = new StringReader(content);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();

            return true;
        }
		catch (Exception)
		{
            return false;
		}
    }
    public List<T> Parse<T>(string content) where T : class
    {
        using var reader = new StringReader(content);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<T>().ToList();

        return records;
    }
}
