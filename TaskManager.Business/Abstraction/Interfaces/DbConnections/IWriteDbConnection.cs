using System.Data;

public interface IWriteDbConnection : IDisposable
{
    Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text,
        int? commandTimeout = null);

    Task<T> ExecuteScalarAsync<T>(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text,
        int? commandTimeout = null);
}