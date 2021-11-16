using Dapper;
using Notes.Repository.Abstractions.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Notes.Repository.Base
{
    public class DbObjectRepository
    {
        private readonly ISqlConnectionObjectFactory _connectionFactory;

        public DbObjectRepository(ISqlConnectionObjectFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IDbConnection OpenConnection()
        {
            var connection = _connectionFactory.GetConnection();
            connection.Open();
            return connection;
        }

        protected async Task<int> ExecuteAsync(string sqlCommand, object? parameter = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection())
            {
                return await ExecuteAsync(sqlCommand, connection, parameter, commandTimeout : commandTimeout);
            }
        }

        protected async Task<int> ExecuteAsync(string sqlCommand, IDbConnection dbConnection, object? parameter = null,
            IDbTransaction? transaction = null, CommandType? commandType = null, int? commandTimeout = null) =>
                    await dbConnection.ExecuteAsync(sqlCommand, parameter, transaction,
                    commandType: commandType, commandTimeout: commandTimeout);

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sqlCommand, object? parameters = null)
        {
            using (var dbConnection = OpenConnection())
            {
                var connection = dbConnection;
                return await connection.QueryAsync<T>(sqlCommand, parameters);
            }
        }
    }
}
