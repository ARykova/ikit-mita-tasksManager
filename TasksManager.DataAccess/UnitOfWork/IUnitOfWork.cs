using System.Threading.Tasks;
using TasksManager.Entities;

namespace TasksManager.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Project> Projects { get; }

        void Migrate();

        int Commit();

        Task<int> CommitAsync();
    }
}
