using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.UnitOfWork;
using TasksManager.Entities;

namespace TasksManager.DataAccess.DbImplementation
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : DomainObject
    {
        private DbSet<TEntity> DbSet { get;}

        public EFRepository(DbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
