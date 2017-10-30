using System.Net.Sockets;
using System.Threading.Tasks;
using TasksManager.Entities;

namespace TasksManager.DataAccess.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : DomainObject
    {
        void Add(TEntity entity);
        Task<TEntity> FindAsync(int id);
    }
}
