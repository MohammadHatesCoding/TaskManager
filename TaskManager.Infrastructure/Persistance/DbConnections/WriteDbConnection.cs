using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TaskManager.Business.Abstraction.Data;

public class WriteDbConnection : IWriteDbConnection
{
    private readonly IDbConnection _connection;

    public WriteDbConnection(IConfiguration configuration)
    {
        _connection = new SqlConnection(
            configuration.GetConnectionString("HRM"));
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

    public Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text,
        int? commandTimeout = null)
        => _connection.ExecuteAsync(
            sql,
            Convert(param),
            transaction,
            commandTimeout,
            commandType);

    public Task<T> ExecuteScalarAsync<T>(
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.Text,
        int? commandTimeout = null)
        => _connection.ExecuteScalarAsync<T>(
            sql,
            Convert(param),
            transaction,
            commandTimeout,
            commandType);

    public void Dispose()
        => _connection.Dispose();
}