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
