using SalesSoftware.Dal.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SalesSoftware.Dal.Connetion;

public class BaseConnection : IBaseConnection
{
    private readonly string _connectionString;
    private IDbConnection? _connection;

    public BaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        if (_connection == null)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }
        return _connection;
    }

    public void Dispose()
    {
        if (_connection != null)
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}
