using System.Data;

namespace TasksManager.DataAccess.Projects
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenedConnection();
    }
}
