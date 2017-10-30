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

        private readonly IRepository<Project> _projects;
        public IRepository<Project> Projects => _projects;

        public UnitOfWork(TasksContext  context)
        {
            Context = context;
            _projects = new EFRepository<Project>(context.Projects);
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
