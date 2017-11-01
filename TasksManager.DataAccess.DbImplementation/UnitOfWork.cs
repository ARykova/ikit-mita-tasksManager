using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TasksManager.DataAccess.UnitOfWork;
using TasksManager.Db;
using TasksManager.Entities;

namespace TasksManager.DataAccess.DbImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private TasksContext Context { get; }

        private readonly IQueryableRepository<Project> _projects;
        public IQueryableRepository<Project> Projects => _projects;

        public UnitOfWork(TasksContext context)
        {
            Context = context;
            _projects = new EFQueryableRepository<Project, TasksContext>(Context);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Migrate()
        {
            Context.Database.Migrate();
        }
    }
}
