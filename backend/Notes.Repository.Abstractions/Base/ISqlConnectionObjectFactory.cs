using System.Data;

namespace Notes.Repository.Abstractions.Base
{
    public interface ISqlConnectionObjectFactory
    {
        IDbConnection GetConnection();
    }
}
