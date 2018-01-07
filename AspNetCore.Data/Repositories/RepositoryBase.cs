using AspNetCore.Data.Context;
using AspNetCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AspNetCoreContext context;

        public RepositoryBase()
        {
             context = new AspNetCoreContext();
        }

        public void Add(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll() => context.Set<TEntity>().ToList();

        public TEntity GetById(int id) => context.Set<TEntity>().Find(id);

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
