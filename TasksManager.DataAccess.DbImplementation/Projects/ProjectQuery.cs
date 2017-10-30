using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.DataAccess.UnitOfWork;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class ProjectQuery : IProjectQuery
    {
        private IUnitOfWork Uow { get; }
        public ProjectQuery(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            var project = await Uow.Projects.FindAsync(projectId);
            if (project != null)
            {
                return new ProjectResponse
                {
                    Id = project.Id,
                    Description = project.Description
                };
            }
            return null;
            //ProjectResponse response = await Uow.Projects
            //    .Select(p => new ProjectResponse
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Description = p.Description,
            //        OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
            //    })
            //    .FirstOrDefaultAsync(pr => pr.Id == projectId);

            //return response;
        }
    }
}
