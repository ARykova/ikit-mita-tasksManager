using System.Threading.Tasks;
using TasksManager.DataAccess.Projects;
using TasksManager.DataAccess.UnitOfWork;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModel.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private IUnitOfWork Uow { get; }
        public CreateProjectCommand(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description
            };

            Uow.Projects.Add(project);
            await Uow.CommitAsync();

            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                OpenTasksCount = 0
            };
        }
    }
}
