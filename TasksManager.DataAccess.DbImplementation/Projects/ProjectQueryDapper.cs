using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TasksManager.DataAccess.Projects;
using TasksManager.Entities;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class ProjectQueryDapper : IProjectQuery
    {
        private readonly IConnectionFactory _factory;

        public ProjectQueryDapper(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            var sql = "select Id, Name, Description from Projects where Id=@Id";
            using (var connection = _factory.GetOpenedConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ProjectResponse>(sql, new {Id = projectId});
            }
        }
    }
}
