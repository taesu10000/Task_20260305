namespace Infrastructure.Parsers;

public class FileStoreService : IFileStoreService
{
    public bool Exists(string path) => File.Exists(path);
    public async Task CombineAsync(string path, string content)
    {
        using var file = new StreamReader(path);
        var fileContent = await file.ReadToEndAsync();
        fileContent += content;

        File.WriteAllText(path, fileContent);
    }
    public async Task SaveAsync(string path, string content, CancellationToken ct = default)
    {
        await File.WriteAllTextAsync(path, content);
    }
}
