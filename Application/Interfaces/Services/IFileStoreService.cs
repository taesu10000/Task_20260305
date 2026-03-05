namespace Infrastructure.Parsers;

public interface IFileStoreService
{
    Task CombineAsync(string path, string content);
    bool Exists(string path);
    Task SaveAsync(string path, string content, CancellationToken ct = default);
}
