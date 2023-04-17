using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace ChumakBank.Persistence.Context;

public sealed class DataContext
{
    private readonly DbSetting _dbSetting;

    public DataContext(IOptions<DbSetting> dbSetting)
    {
        _dbSetting = dbSetting.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _dbSetting.ToString();
        return new NpgsqlConnection(connectionString);
    }

    public async Task CreateDatabase()
    {
        string connString = _dbSetting.ToString();
        await using var connection = new NpgsqlConnection(connString);
        var sqlDbCountQuery = $"select count(*) from pg_database where datname = '{_dbSetting.Database}';";
        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCountQuery);
        if (dbCount == 0)
        {
            var sqlCreateDb = $"create database \"{_dbSetting.Database}\"";
            await connection.ExecuteAsync(sqlCreateDb);
        }
    }
       
}