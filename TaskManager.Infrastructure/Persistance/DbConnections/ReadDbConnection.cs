using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using TaskManager.Business.Abstraction.Data;

public class ReadDbConnection : IReadDbConnection
{
    private readonly IDbConnection _connection;

    public ReadDbConnection(IConfiguration configuration)
    {
        _connection = new SqlConnection(
            configuration.GetConnectionString(""));
    }

    private object? Convert(object? param)
    {
        if (param is null)
            return null;

        if (param is DynamicParameters dp)
            return dp;

        if (param is CustomDynamicParameters customParams)
        {
            var dynamicParams = new DynamicParameters();

            foreach (var p in customParams.AsList())
            {
                dynamicParams.Add(
                    p.Name,
                    p.Value,
                    direction: p.Direction);
            }

            return dynamicParams;
        }

        return param;
    }

    public Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text)
        => _connection.QueryAsync<T>(
            sql,
            Convert(param),
            transaction,
            null,
            commandType);

    public Task<T?> QueryFirstOrDefaultAsync<T>(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text)
        => _connection.QueryFirstOrDefaultAsync<T>(
            sql,
            Convert(param),
            transaction,
            null,
            commandType);

    public Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text)
        => _connection.ExecuteAsync(
            sql,
            Convert(param),
            transaction,
            null,
            commandType);

    public void Dispose()
        => _connection.Dispose();
}