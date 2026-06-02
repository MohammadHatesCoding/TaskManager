using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TaskManager.Business.Abstraction.Interfaces.Services;

namespace TaskManager.Infrastructure.Service;

public class FileService : IFileService
{
    #region
    //private readonly string _baseStoragePath;
    //private readonly string _webRootPath;

    //public FileService(IConfiguration configuration, IWebHostEnvironment env)
    //{
    //    _baseStoragePath = configuration.GetValue<string>("FileStorage:LocalStoragePath") ?? "uploads";
    //    _webRootPath = env.WebRootPath;

    //    EnsureDirectoryExists(Path.Combine(_webRootPath, _baseStoragePath));
    //}

    //public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string contentType)
    //{
    //    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
    //    var fullPath = Path.Combine(_webRootPath, _baseStoragePath, uniqueFileName);

    //    EnsureDirectoryExists(Path.GetDirectoryName(fullPath));

    //    using (var targetStream = new FileStream(fullPath, FileMode.Create))
    //    {
    //        await fileStream.CopyToAsync(targetStream);
    //    }

    //    return Path.Combine(_baseStoragePath, uniqueFileName).Replace("\\", "/");
    //}

    //public async Task<byte[]> GetFileAsync(string fileIdentifier)
    //{
    //    var fullPath = Path.Combine(_webRootPath, fileIdentifier.Replace("/", "\\"));

    //    if (!File.Exists(fullPath))
    //    {
    //        throw new FileNotFoundException($"File not found at path: {fullPath}");
    //    }

    //    return await File.ReadAllBytesAsync(fullPath);
    //}

    //public Task DeleteFileAsync(string fileIdentifier)
    //{
    //    var fullPath = Path.Combine(_webRootPath, fileIdentifier.Replace("/", "\\"));

    //    if (File.Exists(fullPath))
    //    {
    //        File.Delete(fullPath);
    //    }

    //    return Task.CompletedTask;
    //}

    //private void EnsureDirectoryExists(string directoryPath)
    //{
    //    if (!Directory.Exists(directoryPath))
    //    {
    //        Directory.CreateDirectory(directoryPath);
    //    }
    //}
    #endregion

    private readonly string _localStoragePath;
    private readonly IWebHostEnvironment _env;
    
    public FileService(IConfiguration configuration, IWebHostEnvironment env)
    {
        _localStoragePath = configuration.GetValue<string>("FileStorage:LocalStoragePath");
        if (string.IsNullOrEmpty(_localStoragePath))
        {
            _localStoragePath = Path.Combine(env.WebRootPath, "uploads");
        }
        else
        {
            if (!Path.IsPathRooted(_localStoragePath))
            {
            }
        }
        _env = env;
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
    {
        if (fileStream == null || fileStream.Length == 0)
        {
            throw new ArgumentException("File stream cannot be null or empty.");
        }
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentException("File name cannot be null or empty.");
        }

        var extension = Path.GetExtension(fileName);
        var uniqueFileName = $"{Guid.NewGuid()}{extension}";

        var fullPath = Path.Combine(_localStoragePath, uniqueFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

        await using var file = new FileStream(fullPath, FileMode.Create);
        await fileStream.CopyToAsync(file);

        return uniqueFileName;
    }
    public async Task<byte[]> GetFileAsync(string fileIdentifier)
    {
        if (string.IsNullOrEmpty(fileIdentifier))
        {
            throw new ArgumentException("File identifier cannot be null or empty.");
        }

        var fullPath = Path.Combine(_localStoragePath, fileIdentifier);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"File not found at path: {fullPath}");
        }

        return await File.ReadAllBytesAsync(fullPath);
    }

    public Task DeleteFileAsync(string fileIdentifier)
    {
        if (string.IsNullOrEmpty(fileIdentifier))
        {
            throw new ArgumentException("File identifier cannot be null or empty.");
        }

        var fullPath = Path.Combine(_localStoragePath, fileIdentifier);

        if (File.Exists(fullPath))
        {
            try
            {
                File.Delete(fullPath);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file {fullPath}: {ex.Message}");
                throw;
            }
        }
        else
        {
            return Task.CompletedTask;
        }
    }
}