using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TasksManager.DataAccess.Projects;
using TasksManager.Entities;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class CreateProjectDapper : ICreateProjectCommand
    {
        private readonly IConnectionFactory _factory;

        public CreateProjectDapper(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
            var sql = "insert into Projects (Id, Name, Description, TasksCount) values (@Id, @Name, @Description, @TasksCount)";
            using (var connection = _factory.GetOpenedConnection())
            {
                var project = new Project { Name = request.Name, Description = request.Description };
                return await connection.QueryFirstOrDefaultAsync<ProjectResponse>
                    (sql, project);
            }
        }
    }
}
