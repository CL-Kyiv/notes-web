using Microsoft.Data.SqlClient;
using Notes.Core.Configuration;
using Notes.Repository.Abstractions.Base;
using System.Data;

namespace Notes.Repository.Base
{
    public class SqlConnectionObjectFactory : ISqlConnectionObjectFactory
    {
        private readonly DatabaseSettings _databaseSettings;

        public SqlConnectionObjectFactory(DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = 
                $"Server={_databaseSettings.Server};Database={_databaseSettings.Database};User Id={_databaseSettings.User};Password={_databaseSettings.Pass};";
 
            return new SqlConnection(connectionString);
        }
    }
}
