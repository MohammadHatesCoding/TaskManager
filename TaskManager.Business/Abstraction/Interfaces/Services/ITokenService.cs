namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface ITokenService
{
    string Hash(string Token);
    bool Verify(string RawToken, string StoredHash);
}
