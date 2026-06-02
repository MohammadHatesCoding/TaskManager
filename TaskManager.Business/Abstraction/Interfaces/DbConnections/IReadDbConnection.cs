using System.Data;

public interface IReadDbConnection : IDisposable
{
    Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text);

    Task<T?> QueryFirstOrDefaultAsync<T>(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text);

    Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text);
}