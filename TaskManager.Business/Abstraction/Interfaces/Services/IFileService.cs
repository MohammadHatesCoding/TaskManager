namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(Stream fileStream, string fileName);
    Task<byte[]> GetFileAsync(string fileIdentifier);
    Task DeleteFileAsync(string fileIdentifier);
}
